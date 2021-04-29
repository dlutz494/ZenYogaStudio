namespace YogaStudio.App.Models.BindingModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using YogaStudio.App.Models.Attributes;

    public class CreditCardBindingModel
    {
        public int? Id { get; set; }

        [Required]
        [DisplayName("Card Name")]
        [RegularExpression(@"\b\w+\s{1}\w+\b", ErrorMessage = GlobalConstants.CreditCardNameValidationMessage)]
        public string CardName { get; set; }

        [Required]
        [DisplayName("Card Number")]
        [Visa(ErrorMessage = GlobalConstants.VisaValidationMessage)]
        public string CardNumber { get; set; }

        [Required]
        [DisplayName("Expiry Date")]
        [RegularExpression(@"\b\d{2}\/\d{2}\b", ErrorMessage = GlobalConstants.CreditCardExpiryDateValidationMessage)]
        public string ExpiryDate { get; set; }

        [Required]
        [DisplayName("Security Code")]
        [RegularExpression(@"\b\d{3}\b", ErrorMessage = GlobalConstants.CreditCardSecurityCodeValidationMessage)]
        public string SecurityCode { get; set; }
    }
}