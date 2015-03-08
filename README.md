# Launch Sitecore TDS #

- Use Tag 1.0 with Sitecore 6.5 Service Pack 2 (rev. 121009) - Launch Sitecore Classic version
- Use Tag 1.1 with Sitecore 7.0 Update 3 (rev. 131127) - Launch Sitecore Classic version
- Use Tag 2.0.0.1 with Sitecore 7.1 Update 1 (rev. 140130) - Launch Sitecore New Themed version
- Use Tag 2.0.1.0 with Sitecore 7.1 Update 1 (rev. 140130) - Launch Sitecore - both WebForms and MVC versions
- Use Tag 2.1.0.0 with Sitecore 7.2 Update 2 (rev. 140526) - Launch Sitecore - both WebForms and MVC versions
- Use Tag 2.2.0.0 with Sitecore 7.5 Initial Release (rev. 141003) - Launch Sitecore - both WebForms and MVC versions.
- Use Tag 2.3.0.0 with Sitecore 8.0 Update 2 (rev. 150223) - Launch Sitecore - both WebForms and MVC versions.

Launch Sitecore is a site found at [www.launchsitecore.net](www.launchsitecore.net). It is a fantastic, shared source site that shows the power of Sitecore through Page Editor and DMS. The site comes complete with content, components, engagement plans and much more. A Sitecore package for the complete site can be downloaded from the above link after registering.

This repository is that package converted to a Visual Studio solution with items in Team Development for Sitecore. It's intended to serve as a platform for helping developers understand TDS, Glass Mapper, and Code Generation with TDS. It also allows developers to quickly setup a site with content, so that other additional features can be tested on a complete site.


## To get up and running ##
### Quick Guide ###
- Install a blank instance of Sitecore using SIM.
- Update Include configs so your data folder points locally, and you're running in Live mode.
- Copy the required Sitecore DLLs to the `Installers\Sitecore` folder.
- Within either the MVC or WebForms solution, setup your local TDS settings, either by changing the `TdsGlobal.config` file, or by duplicating it with the name `TdsGlobal.config.user`
- Deploy the solution, so code and items are deployed to your local instance.
- Perform post-build steps: Rebuild Indexes, Deploy Campaigns and Goals, Rebuild the Links Database

### Detailed Guide ###

#### Install a blank Sitecore Instance ####
- Install a blank instance of Sitecore using the Sitecore Instance Manager.
- Ensure that you install Analytics from the second step. You must have the DMS version available to you.
- Click Open folder when installation is complete.

#### Update your local settings ####
- Navigate to the App_Config/Include folder.
- Change the name of DataFolder.config.example to DataFolder.config.
- Open the file, and change the value to that used by your site. Save and Exit.
- Copy the `zz_developer.config` file in {GitRootDirectory}/Installers over to In App_Config/Include. This config file will make your site run in live mode.

#### Place Sitecore DLLs in the Installers folder ####
- Follow the steps in the {GitRootDirectory}/Installers/Sitecore/README.txt file, which tells you which Sitecore DLLs need to be referenced in code.

#### Open the solution you wish to use ####
Open `LaunchSitecore.sln` for the WebForms version of the site.<br />
Open `LaunchSitecoreMvc.sln` for the MVC version of the site.

The two solutions share some projects, but can be built and deployed irrespective of each other.
*Note:* You should only use one solution per Sitecore Instance. You cannot deploy both solutions to the same Sitecore instance.

#### Set your TDS Deployment Settings ####
- In the root directory of the solution, duplicate the `TdsGlobal.config` file, naming it `TdsGlobal.config.user`.
- Open the new file, and for your configuration (most likely Debug) uncomment the nodes `SitecoreWebUrl`, `SitecoreDeployFolder`.
 - For each of these nodes, add in your unique website information. e.g:- <br />
   `<SitecoreWebUrl>http://launch.local</SitecoreWebUrl>`<br />
   `<SitecoreDeployFolder>D:\Sites\Launch\Website</SitecoreDeployFolder>`<br />
- Save the file. This will tell TDS to use these settings for all TDS projects.

#### Build and Deploy ####
- Right click on the solution and select 'Deploy Solution'.

#### Rebuild Search Indexes ####
When using a Sitecore 7+ version, you will need to rebuild the indexes for the site to work correctly. (Noticeable with the carousel on the homepage in the new themed version).<br />
To rebuild the indexes:-

 - Open the Sitecore Client, and login to *Desktop* mode.
 - From the Sitecore Start menu, Open the *Control Panel*.
 - Click on *Indexing*.
 - Click on *Indexing Manager*
 - Follow the Wizard, selecting all of the local instances and clicking on the *Rebuild* button.

#### Optional: Deploy the Example Campaign ####
In order to push your campaigns to the Analytics database and be active on the site, you will need to re-deploy them.

 - In the Sitecore Content Editor, turn on Standard Fields (`View -> View -> Standard Fields`)
 - Navigate to the Example Campaign (`/sitecore/system/Marketing Center/Campaigns/Example Campaign`).
 - Change the Workflow State to Draft. (`Worflow section -> Field: State` set to `Analytics Workflow -> Draft`). Save the item.
 - Deploy the campaign. (`Review` ribbon -> `Workflow` chunk, `Deploy`)
 

#### Optional: Rebuild the Link Database ####
For better navigation around the site, it is recommended that you rebuild the link database after the deployment.

 - Open the Sitecore Client, and login to *Desktop* mode.
 - From the Sitecore Start menu, Open the *Control Panel*.
 - Click on *Database*.
 - Click on *Rebuild the Link Database*
 - Follow the Wizard, selecting *core* and *master* databases and clicking on the *Rebuild* button.

Your site should now be completely setup.

## Differences with LaunchSitecore.net package ##
### Code differences ###
Some custom code has been added to flush the contact data to the xDB. In each of the files below, we explicitly call Session.Abandon(), which will flush the data for us.

 - TertiaryNav.ascx.cs 
 - AccountController.cs

layouts/LaunchSitecore/Main.aspx.designer.cs in the package has a removed reference to the sc:VisitorIdentification control...yet the aspx still has it. In this solution, we keep it there to comply with WebForms standards.

www.LaunchSitecore.config - changes with the SC8 package removed sections of config for ribbon buttons (see item differences for ribbons below). The comment mentions it's only for the Technical Preview of Sitecore 8. We've left these in, until we see any issues arise from it.

### Item differences ###
 - master: /sitecore/system/Settings/Rules/ConditionalRenderings/Tags/Default
  - the TDS project has added tag on this item for 'Engagement Automation'. This tag existed in the 7.2 package but was removed from 7.5 package.

 - master: /sitecore/templates/Launch Sitecore/Article Group
  - in package it inherits from GeneralFields, but also SiteSection, which inherits from GeneralFields... so they creates a duplicate dependency and breaks code generation.

 - core: /sitecore/content/Applications/WebEdit/Ribbons/WebEdit/Page Editor/Site Configuration
  - both Site Presentation and Site Settings ribbon buttons were removed from the package, as these don't work with the SPEAK Experience Editor. They're left in for backwards reference.

 - master: /sitecore/layout/Sublayouts/LaunchSitecore/Controls/Single Item
  - (WebForms project) 3 renderings have included the Page Editor Buttons field containing the 'Common' button. This is what the MVC project has, but the package doesn't contain it for WebForms.
  - Article Title and Body
  - Article Title Image and Body
  - Biography

 



