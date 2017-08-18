namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
  #region Usings

  using System.ComponentModel.DataAnnotations;
  using System.Linq;
  using Sitecore.Forms.Mvc.Validators;
  using Sitecore.Forms.Mvc.ViewModels.Fields;
  using WFFM.Abstractions.Actions;

  #endregion

  public class TelephoneField : SingleLineTextField
  {
    public override ControlResult GetResult()
    {
      return Value == null ? base.GetResult() : new ControlResult(FieldItemId, Title, new string(Value.Where(char.IsDigit).ToArray()), string.IsNullOrEmpty(Value) ? null : string.Join(string.Empty, "<scfriendly>", Value, "</scfriendly>"));
    }

    [DynamicRegularExpression(@"^\+?\s{0,}\d{0,}\s{0,}(\(\s{0,}\d{1,}\s{0,}\)\s{0,}|\d{0,}\s{0,}-?\s{0,})\d{2,}\s{0,}-?\s{0,}\d{2,}\s{0,}(-?\s{0,}\d{2,}|\s{0,})\s{0,}$", null, ErrorMessage = "The {0} field contains an invalid telephone number."), DataType(DataType.PhoneNumber)]
    public override string Value { get; set; }
  }
}
