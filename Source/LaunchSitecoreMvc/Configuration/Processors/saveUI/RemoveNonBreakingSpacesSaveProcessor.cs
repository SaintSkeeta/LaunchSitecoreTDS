using Sitecore.Pipelines.Save;

namespace LaunchSitecore.Configuration.Processors.saveUI
{
  // The html editor occasionally puts in a non-breaking space instead of a space.  Since this is not xhtml compatible, I am removing them on save.
  public class RemoveNonBreakingSpacesSaveProcessor
  {
    public void Process(SaveArgs args)
    {
      foreach (Sitecore.Pipelines.Save.SaveArgs.SaveItem saveItem in args.Items)
      {
        foreach (Sitecore.Pipelines.Save.SaveArgs.SaveField saveField in saveItem.Fields)
        {
          // remove the &nbsp; characters
          saveField.Value = saveField.Value.Replace("&nbsp;", " ");
        }
      }
    }
  }
}