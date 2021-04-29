namespace YogaStudio.App.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class VisaAttribute : RegularExpressionAttribute
    {
        public VisaAttribute()
            : base("^4[0-9]{3}\\s?[0-9]{4}\\s?[0-9]{4}\\s?(?:[0-9]{4})?$")
        {
        }
    }
}