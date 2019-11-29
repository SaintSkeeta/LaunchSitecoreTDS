using Sitecore.Analytics;
using Sitecore.Analytics.Data;
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

                https://doc.sitecore.com/developers/90/sitecore-experience-platform/en/triggering-custom-events.html
                var ev = Sitecore.Analytics.Tracker.MarketingDefinitions.Outcomes[_justinWestContactOutcomeId];

                if (ev != null)
                {
                    var outcomeData = new Sitecore.Analytics.Data.OutcomeData(ev, "USD", 100.00m);

                    outcomeData.CustomValues.Add("DateTime", DateTime.UtcNow.Date.ToString()); // Never saved to xConnect, must be converted into a property on a custom model

                    Sitecore.Analytics.Tracker.Current.CurrentPage.RegisterOutcome(outcomeData);
                }

                //TODO: (if we need the DateTime property https://doc.sitecore.com/developers/90/sitecore-experience-platform/en/convert-an-outcome.html
            }

            return "Triggered";
        }
    }
}