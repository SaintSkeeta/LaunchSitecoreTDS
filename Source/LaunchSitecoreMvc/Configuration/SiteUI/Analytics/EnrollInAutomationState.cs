using Sitecore.Rules;
using Sitecore.Rules.Actions;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using System;
using Sitecore.Analytics.Automation;
using Sitecore.Analytics.Automation.Data;

namespace LaunchSitecore.Configuration.SiteUI.Analytics
{
    // Created Sitecore Item "/sitecore/system/Settings/Rules/Common/Actions/EnrollInAutomationState" when creating EnrollInAutomationState class. Fix Title field.

    public class EnrollInAutomationState<T> : RuleAction<T> where T : RuleContext
    {
        public string StateId { get; set; }        

        public override void Apply([NotNull] T ruleContext)
        {
            // Execute action
            Item state = Sitecore.Context.Database.GetItem(new ID(StateId));
            if (state != null && state.Template.Key == "engagement plan state")
            {
             //This is how you add a contact out of context, but I am in context, so the below lines are correct.
             //Sitecore.Analytics.Automation.AutomationContactManager.AddContact(Sitecore.Analytics.Tracker.Current.Contact.ContactId, state.ID);            

             var a = AutomationStateManager.Create(Sitecore.Analytics.Tracker.Current.Contact);
             a.EnrollInEngagementPlan(state.ParentID, state.ID);                
            }            
        }
    }
}