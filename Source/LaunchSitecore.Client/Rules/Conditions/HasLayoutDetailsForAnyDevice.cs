namespace LaunchSitecore.Rules.Conditions
{
    public class HasLayoutDetailsForAnyDevice<T> :
      Sitecore.Rules.Conditions.OperatorCondition<T>
      where T : Sitecore.Rules.RuleContext
    {
        protected override bool Execute(T ruleContext)
        {
            foreach (Sitecore.Data.Items.DeviceItem compare
              in ruleContext.Item.Database.Resources.Devices.GetAll())
            {
                if (ruleContext.Item.Visualization.GetLayout(compare) != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}