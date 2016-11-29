using Sitecore.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Rules;

namespace LaunchSitecore.Configuration.Rules
{
    public class QueryStringCondition<T> : WhenCondition<T> where T : RuleContext
    {
        public string QueryStringKey { get; set; }
        public string QueryStringValue { get; set; }

        protected override bool Execute(T ruleContext)
        {
            string qs = HttpContext.Current.Request.QueryString[QueryStringKey];
            if (qs == QueryStringValue)
            {
                return true;
            }
            return false;
        }
    }
}