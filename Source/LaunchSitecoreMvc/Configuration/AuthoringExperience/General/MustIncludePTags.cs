using Sitecore;
using Sitecore.Data.Validators;
using System;
using System.Runtime.Serialization;

namespace LaunchSitecore.Configuration.AuthoringExperience.General
{
  /// <summary>
  /// Defines the must include p tags  validator class.
  /// </summary>
  [Serializable]
  public class MustIncludePTags : StandardValidator
  { 
    public MustIncludePTags(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MustIncludePTags()
    {
    }

    public override string Name
    {
      get
      {
        return "Must Include P Tags";
      }
    }

    protected override ValidatorResult GetMaxValidatorResult()
    {
      return this.GetFailedResult(ValidatorResult.Error);
    }

    protected override ValidatorResult Evaluate()
    {
      string text = this.ControlValidationValue.Trim();
      if (string.IsNullOrEmpty(text) || text.Contains("<p>") || text.Contains("<P>"))
        return ValidatorResult.Valid;
      this.Text = this.GetText("\"{0}\" doesn't contain paragraph tags.", new string[1]
      {
        this.GetFieldDisplayName()
      });
      return this.GetFailedResult(ValidatorResult.Warning);
    }  
  }
}
