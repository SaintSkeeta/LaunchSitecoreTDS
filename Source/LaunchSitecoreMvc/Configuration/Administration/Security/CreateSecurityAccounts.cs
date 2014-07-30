using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Security.Accounts;
using System.Web.Security;
using Sitecore.Web.UI.WebControls;
using Sitecore.SecurityModel;
using System.Collections.Generic;
using Sitecore.Security.AccessControl;
using Sitecore.Security;
using System;

namespace LaunchSitecore.Configuration.Administration.Security
{
  public class CreateSecurityAccounts : Command
  {
    public override void Execute(CommandContext context)
    {
      //Disable security and create accounts
      using (new SecurityDisabler())
      {
        try
        {
          CreateAccounts();
        }
        catch (Exception ex)
        {
          Log.Info(ex.Message.ToString(), this);
        }
      }

      AjaxScriptManager.Current.Dispatch("usermanager:refresh");
    }
        
    public static void CreateAccounts()
    {
      // Instatiate object from class;
      SampleAccounts sampleaccounts = new SampleAccounts();

      Item item = Sitecore.Client.CoreDatabase.GetItem("/sitecore/system/Settings/Security/Profiles/User");
      Assert.IsNotNull(item, "Item \"/sitecore/system/Settings/Security/Profiles/User\" not found");
           
      foreach (UserAccount myUser in sampleaccounts.UserAccounts)
      {
        // delete user if exists
        if (User.Exists(myUser.UserName.ToString()))
        {
          User user = User.FromName(myUser.UserName, true);
          user.Delete();
        }

        // Create User if not exists
        if (!User.Exists(myUser.UserName.ToString()))
        {
          User.Create(myUser.UserName, myUser.Password);
        }

        // If user not in role, add user to role
        foreach (string roleName in myUser.UserAddToRoles)
        {
          //System.Web.Security.Roles.
          if (!Roles.IsUserInRole(myUser.UserName, roleName))
          {
            //System.Web.Security.Roles.
            Roles.AddUserToRole(myUser.UserName, roleName);
          }
        }

        // Need to Add USer Profile Stuff
        // get user and then profile; edit profile
        // Sitecore.Security.Accounts.User AND Sitecore.Security.UserProfile
        User newUser = User.FromName(myUser.UserName, true);
        UserProfile profile = newUser.Profile;

        // Edit profile with defined class properties
        profile.Initialize(myUser.UserName, true);
        profile.ProfileItemId = item.ID.ToString();
        profile.FullName = myUser.FullName.ToString();
        profile.Portrait = myUser.Portrait.ToString();
        profile.Comment = myUser.Comment.ToString();
        profile.Email = myUser.Email.ToString();         
        profile.SetCustomProperty("Wallpaper", myUser.Wallpaper);
        profile.RegionalIsoCode = string.Empty;


        // for bill and hidden items
        // profile["Sitecore.Shell.UserOptions.View.ShowHiddenItems"] = "true";
        profile.Save();

        // Enable the Account
        MembershipUser mUser = Membership.GetUser(myUser.UserName);
        try
        {
          mUser.IsApproved = true;
          Membership.UpdateUser(mUser);
          continue;
        }
        catch
        {
          continue;
        }
      }      
    }

    private void SetAccessRightsForAccounts()
    {

      // fix on master and core database for Bill
      // Set Security for Sample Worfklow Item wiht SetRight Methods
      // Needs to be done after account creation and programtically
      // Updated for Core database edits

      List<AccessRight> sampleWorkflowRights = new List<AccessRight>{AccessRight.ItemRead, 
                                                             AccessRight.ItemWrite,
                                                             AccessRight.ItemCreate,
                                                             AccessRight.ItemDelete,
                                                             AccessRight.ItemRename,
                                                             AccessRight.WorkflowCommandExecute,
                                                             AccessRight.WorkflowStateDelete,
                                                             AccessRight.WorkflowStateWrite};

      List<AccessRight> editButtonRights = new List<AccessRight>{
                                                             AccessRight.InsertShow,
                                                             AccessRight.ItemAdmin,
                                                             AccessRight.ItemCreate,
                                                             AccessRight.ItemDelete,
                                                             AccessRight.ItemRead, 
                                                             AccessRight.ItemRename,
                                                             AccessRight.ItemWrite
                                                             };

      List<AccessRight> defaultButtonRights = new List<AccessRight>{
                                                             AccessRight.InsertShow,
                                                             AccessRight.ItemAdmin,
                                                             AccessRight.ItemCreate,
                                                             AccessRight.ItemDelete,
                                                             AccessRight.ItemRead, 
                                                             AccessRight.ItemRename,
                                                             AccessRight.ItemWrite
                                                             };

      List<AccessRight> coreLanguageRights = new List<AccessRight>{AccessRight.ItemRead, 
                                                             AccessRight.ItemWrite,
                                                             AccessRight.ItemCreate, 
                                                             AccessRight.LanguageRead,
                                                             AccessRight.LanguageWrite};

      //SetRights
      SetRight("master", "/sitecore/system/Workflows/Regular Workflow", @"sitecore\Bill", sampleWorkflowRights);
      //SetRight("core", "/sitecore/content/Applications/WebEdit/Edit Frame Buttons", @"sitecore\Bill", editButtonRights);
      //SetRight("core", "/sitecore/content/Applications/WebEdit/Edit Frame Buttons/Default", @"sitecore\Bill", defaultButtonRights);
      //SetRight("core", "/sitecore/content/Applications/WebEdit/Edit Frame Buttons/Default/Edit related item", @"sitecore\Bill", defaultButtonRights);
      //SetRight("core", "/sitecore/content/Applications/WebEdit/Edit Frame Buttons/Default/Insert", @"sitecore\Bill", defaultButtonRights);
      //SetRight("core", "/sitecore/content/Applications/WebEdit/Edit Frame Buttons/Default/Edit", @"sitecore\Bill", defaultButtonRights);

      SetRight("core", "/sitecore/system/Languages/en", @"sitecore\Bill", coreLanguageRights);
    }

    private void SetRight(string strDatabase, string strItem, string strAccount, List<AccessRight> rights)
    {
      //Get Access Rules, Set Access Rules
      try
      {
        Sitecore.Data.Database db = Sitecore.Configuration.Factory.GetDatabase(strDatabase);
        Item item = db.GetItem(strItem);
        AccountType accountType = AccountType.User;
        Account account = Account.FromName(strAccount, accountType);
        AccessPermission rightState = AccessPermission.Allow;

        if (Sitecore.Security.SecurityUtility.IsRole(strAccount))
        {
          accountType = Sitecore.Security.Accounts.AccountType.Role;
        }

        AccessRuleCollection accessRules = item.Security.GetAccessRules();

        foreach (AccessRight right in rights)
        {
          try
          {
            accessRules.Helper.RemoveExactMatches(account, right);
          }
          catch (Exception ex)
          {
            Log.Debug("accessRules.Helper.RemoveExactMatches " + ex.Message.ToString());
          }

          try
          {
            accessRules.Helper.AddAccessPermission(account, right, PropagationType.Entity, rightState);
            accessRules.Helper.AddAccessPermission(account, right, PropagationType.Descendants, rightState);
            Log.Debug(account.Name.ToString() + " has access right of " + right.Name.ToString() + " for " + strItem);
          }
          catch (Exception ex)
          {
            Log.Debug("accessRules.Helper.AddAccessPermission " + ex.Message.ToString());
          }
        }


        item.Security.SetAccessRules(accessRules);
      }
      catch
      (Exception ex)
      {
        Log.Debug(ex.Message.ToString());
      }

    }
  }
  
  public class UserAccount
  {
    // Fields
    private string _username;
    private string _password;
    private string _fullname;
    private string _portrait;
    private string _comment;
    private string _email;
    private string _wallpaper;
    private string[] _userAddToroles;

    // Properties
    public string UserName
    {
      get { return _username; }
      set { _username = value; }
    }

    public string Password
    {
      get { return _password; }
      set { _password = value; }
    }


    public string FullName
    {
      get { return _fullname; }
      set { _fullname = value; }
    }

    public string Portrait
    {
      get { return _portrait; }
      set { _portrait = value; }
    }

    public string Comment
    {
      get { return _comment; }
      set { _comment = value; }
    }

    public string Email
    {
      get { return _email; }
      set { _email = value; }
    }
    public string Wallpaper
    {
      get { return _wallpaper; }
      set { _wallpaper = value; }

    }
    public string[] UserAddToRoles
    {
      get { return _userAddToroles; }
      set { _userAddToroles = value; }
    }

  }

  public class SampleAccounts
  {
    // TrainingAccounts has class property UsersAccounts, a generic List collection of type UserAccount
    // Property is used to create class instances of UserAccount using a terser syntax for setting properties on them  
    public List<UserAccount> UserAccounts
    {
      get
      {
        List<UserAccount> accounts = new List<UserAccount>{
                new UserAccount {UserName = @"sitecore\Bill", 
                                Password = "b",
                                FullName = "Bill Website Developer",
                                Portrait = "people/16x16/dude3.png",
                                Comment = "Bill works as a website Developer. He is a predefined user for this sample site.",
                                Email = "bill.websitedeveloper@sitecore.net",
                                Wallpaper = "/sitecore/shell/themes/backgrounds/lighthouse.jpg",
                                UserAddToRoles = new string[] {@"sitecore\Developer",
                                  @"sitecore\Analytics Content Profiling",
						                      @"sitecore\Analytics Maintaining",
                                  @"sitecore\Sitecore Client Publishing"
                                }},
                new UserAccount {UserName = @"sitecore\Denny", 
                                Password = "d",
                                FullName = "Denny Page Designer",
                                Portrait = "people/16x16/dude1.png",
                                Comment = "Denny works as a Page Designer. He is a predefined user for this sample site.",
                                Email = "denny.designer@sitecore.net",
                                Wallpaper = "/sitecore/shell/themes/backgrounds/keyboard.jpg",
                                UserAddToRoles = new string[] {@"sitecore\Designer"}},
                new UserAccount {UserName = @"sitecore\Lonnie", 
                                Password = "l",
                                FullName = "Lonnie Limited Content Author User",
                                Portrait = "other/16x16/woman2.png",
                                Comment = "Lonnie works as a Content Author with Limited Access rights. She is a predefined user for this sample site.",
                                Email = "Lonnie.LimitedContentAuthorUser@sitecore.net",
                                Wallpaper = "/sitecore/shell/themes/backgrounds/sparkle.jpg",
                                UserAddToRoles = new string[] {@"sitecore\Author",
                                  @"sitecore\Sitecore Limited Content Editor", 
                                  @"sitecore\Sitecore Limited Page Editor"
                                }},
                new UserAccount {UserName = @"sitecore\Minnie", 
                                Password = "m",
                                FullName = "Minnie Minimal Page Editor User",
                                Portrait = "people/16x16/nurse2.png",
                                Comment = "Minnie works as a Page Editor with minimal Access rights. She is a predefined user for this sample site.",
                                Email = "Minnie.MinimalPageEditorUser@sitecore.net",
                                Wallpaper = "/sitecore/shell/themes/backgrounds/building.jpg",
                                UserAddToRoles = new string[] {@"sitecore\Author",
                                  @"sitecore\Sitecore Minimal Page Editor"
                                }},
                new UserAccount {UserName = @"sitecore\Audrey", 
                                Password = "a",
                                FullName = "Audrey Normal Content Author User",
                                Portrait = "other/16x16/woman3.png",
                                Comment = "Audrey works as a Content Author. She is a predefined user for this sample site.",
                                Email = "Audrey.NormalContentAuthorUser@sitecore.net",
                                Wallpaper = "/sitecore/shell/themes/backgrounds/working.jpg",
                                UserAddToRoles = new string[] {@"sitecore\Author",
                                  @"sitecore\Sitecore Client Publishing"
                                }}
            };
        return accounts;
      }
    }
  }
}