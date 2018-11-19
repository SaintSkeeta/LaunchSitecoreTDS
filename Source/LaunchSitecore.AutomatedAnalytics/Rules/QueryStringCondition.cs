using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LaunchSitecore.AutomatedAnalytics.Rules
{
    /// <summary>
    /// Condition class for query string.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    public class QueryStringCondition<T> : StringOperatorCondition<T> where T : RuleContext
    {
        /// <summary>
        /// Gets or sets query string name.
        /// </summary>
        public string QueryStringName { get; set; }

        /// <summary>
        /// Gets or sets query string name.
        /// </summary>
        public string QueryStringValue { get; set; }

        /// <summary>
        /// Main execute method.
        /// </summary>
        /// <param name="ruleContext">Rule context.</param>
        /// <returns>True or false.</returns>
        protected override bool Execute(T ruleContext)
        {
            bool returnValue = false;
            bool foundExactMatch = false;
            bool foundCaseInsensitiveMatch = false;
            bool foundContains = false;
            bool foundStartsWith = false;
            bool foundEndsWith = false;

            Assert.ArgumentNotNull(ruleContext, "ruleContext");

            string myQueryStringName = this.QueryStringName ?? string.Empty;
            string myQueryStringValue = this.QueryStringValue ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(myQueryStringName))
            {
                if (HttpContext.Current != null)
                {
                    // Populated with QueryString coming into current Page
                    string incomingQueryStringValue = HttpContext.Current.Request.QueryString[myQueryStringName] ?? string.Empty;

                    if (incomingQueryStringValue == myQueryStringValue)
                    {
                        // Indicates that QueryString coming into Page is equal to QueryString selected by Content Author
                        foundExactMatch = true;
                        foundCaseInsensitiveMatch = true;
                        foundContains = true;
                        foundStartsWith = true;
                        foundEndsWith = true;

                        return true;
                    }
                    else if (incomingQueryStringValue.ToLower(CultureInfo.InvariantCulture) == myQueryStringValue.ToLower(CultureInfo.InvariantCulture))
                    {
                        // Indicates that QueryString coming into Page has case-insensitive match to QueryString selected by Content Author
                        foundCaseInsensitiveMatch = true;

                        // Check other "Found" variables that are not inherently true
                        if (incomingQueryStringValue.Contains(myQueryStringValue))
                        {
                            foundContains = true;
                        }

                        if (incomingQueryStringValue.StartsWith(myQueryStringValue, true, CultureInfo.InvariantCulture))
                        {
                            foundStartsWith = true;
                        }

                        if (incomingQueryStringValue.EndsWith(myQueryStringValue, true, CultureInfo.InvariantCulture))
                        {
                            foundEndsWith = true;
                        }
                    }
                    else if (incomingQueryStringValue.Contains(myQueryStringValue))
                    {
                        // Indicates that QueryString coming into Page contains QueryString selected by Content Author
                        foundContains = true;

                        // Check other "Found" variables that are not inherently true
                        if (incomingQueryStringValue.StartsWith(myQueryStringValue, true, CultureInfo.InvariantCulture))
                        {
                            foundStartsWith = true;
                        }

                        if (incomingQueryStringValue.EndsWith(myQueryStringValue, true, CultureInfo.InvariantCulture))
                        {
                            foundEndsWith = true;
                        }
                    }
                }
            }

            switch (this.GetOperator())
            {
                case StringConditionOperator.Equals: returnValue = foundExactMatch; break;
                case StringConditionOperator.NotEqual: returnValue = !foundExactMatch; break;
                case StringConditionOperator.CaseInsensitivelyEquals: returnValue = foundCaseInsensitiveMatch; break;
                case StringConditionOperator.NotCaseInsensitivelyEquals: returnValue = !foundCaseInsensitiveMatch; break;
                case StringConditionOperator.Contains: returnValue = foundContains; break;
                case StringConditionOperator.StartsWith: returnValue = foundStartsWith; break;
                case StringConditionOperator.EndsWith: returnValue = foundEndsWith; break;
                default: returnValue = false; break;
            }

            return returnValue;
        }
    }
}