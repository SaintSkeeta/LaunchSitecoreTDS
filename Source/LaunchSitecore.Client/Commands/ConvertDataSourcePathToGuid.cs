using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchSitecore.Commands
{
    public class ConvertDataSourcePathToGuid : Command
    {
        public override void Execute(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");

            var currentItem = context.Items[0];
            if (currentItem == null)
                return;

            // rules to invoke
            Sitecore.Rules.RuleList<Sitecore.Rules.RuleContext> rules = this.GetRule(currentItem.Database);
            Assert.IsNotNull(rules, "rules");

            Sitecore.Rules.RuleContext ruleContext = new Sitecore.Rules.RuleContext();
            ruleContext.Item = currentItem;

            rules.Run(ruleContext);
        }

        // retrieve the rules to invoke
        protected Sitecore.Rules.RuleList<Sitecore.Rules.RuleContext> GetRule(Sitecore.Data.Database db)
        {
            // items that define the rules to invoke
            List<Sitecore.Data.Items.Item> ruleItems = new List<Sitecore.Data.Items.Item>();

            Sitecore.Rules.RuleList<Sitecore.Rules.RuleContext> rules = new Sitecore.Rules.RuleList<Sitecore.Rules.RuleContext>();
            rules.Name = "Apply Data Source ID";

            Item ruleItem = db.GetItem("/sitecore/system/settings/rules/item saved/rules/apply data source IDs");
            string ruleXml = ruleItem["Rule"];

            if (String.IsNullOrEmpty(ruleXml) || ruleItem["Disabled"] == "1")
            {
                return rules;
            }

            Sitecore.Rules.RuleList<Sitecore.Rules.RuleContext> parsed = Sitecore.Rules.RuleFactory.ParseRules<Sitecore.Rules.RuleContext>(
                  db,
                  ruleXml);
            rules.AddRange(parsed.Rules);

            return rules;
        }
    }
}