using Sitecore.Analytics.Outcome;
using Sitecore.Analytics.Outcome.Model;
using Sitecore.Configuration;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaunchSitecore.AutomatedAnalytics.Controllers
{
    public class OutcomeTriggerController : Controller
    {
        private Sitecore.Data.ID _justinWestContactOutcomeId = new Sitecore.Data.ID("{AF18DCC7-9A03-4FB8-A848-D259654EA4BE}");
        
        public string TriggerJustinWestContactOutcome()
        {
            if (Sitecore.Context.PageMode.IsNormal)
            {
                //code to trigger an outcome from http://sitecore-community.github.io/docs/xDB/outcomes/
                ID id = Sitecore.Data.ID.NewID;
                ID interactionId = Sitecore.Data.ID.NewID;
                ID contactId = Sitecore.Data.ID.NewID;

                var outcome = new ContactOutcome(id, _justinWestContactOutcomeId, contactId)
                {
                    DateTime = DateTime.UtcNow.Date,
                    MonetaryValue = 10,
                    InteractionId = interactionId
                };

                var manager = Factory.CreateObject("outcome/outcomeManager", true) as OutcomeManager;
                manager.Save(outcome);
            }

            return "Triggered";
        }
    }
}