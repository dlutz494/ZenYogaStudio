namespace YogaStudio.App.Models
{
    public class GlobalConstants
    {
        public const string RequiredValidationMessage = "The {0} is required.";
        public const string StringLengthValidationMessage = "The {0} should be between {2} and {1}.";
        public const string PhoneNumberValidationMessage = "Not a valid Phone number.";
        public const string CreditCardNameValidationMessage = "Not a valid name.";
        public const string CreditCardNumberValidationMessage = "Not a valid number. (Ex. 4111111111111111)";
        public const string CreditCardExpiryDateValidationMessage = "Not a valid expiry date. (Ex. mm/yy)";
        public const string CreditCardSecurityCodeValidationMessage = "Not a valid security code (Ex. 123).";
        public const string UrlValidationMessage = "The {0} is invalid!";
        public const string TotalPriceValidationMessage = "Price should be between {1} and {2}.";
        public const string VisaValidationMessage = "This is not a valid Visa card number.";
    }
}