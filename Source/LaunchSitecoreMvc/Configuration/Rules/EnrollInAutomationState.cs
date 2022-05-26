using Sitecore.Rules;
using Sitecore.Rules.Actions;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using System;
//using Sitecore.Analytics.Automation;
//using Sitecore.Analytics.Automation.Data;

namespace LaunchSitecore.Configuration.Rules
{
    // Reference Item: /sitecore/system/Settings/Rules/Definitions/Elements/Launch Sitecore/Enroll In Automation State

    public class EnrollInAutomationState<T> : RuleAction<T> where T : RuleContext
    {
        public string StateId { get; set; }        

        public override void Apply(T ruleContext)
        {
            // Execute action
        //    Item state = Sitecore.Context.Database.GetItem(new ID(StateId));
        //    if (state != null && state.Template.Key == "engagement plan state")
        //    {
        //     //This is how you add a contact out of context, but I am in context, so the below lines are proper way.
        //     //Sitecore.Analytics.Automation.AutomationContactManager.AddContact(Sitecore.Analytics.Tracker.Current.Contact.ContactId, state.ID);            

        //     var a = AutomationStateManager.Create(Sitecore.Analytics.Tracker.Current.Contact);
        //     a.EnrollInEngagementPlan(state.ParentID, state.ID);                
        //    }            
        }
    }
}