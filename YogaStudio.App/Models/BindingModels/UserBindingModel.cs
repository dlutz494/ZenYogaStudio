namespace YogaStudio.App.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using YogaStudio.App.Models.Enums;

    public class UserBindingModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [StringLength(100, ErrorMessage = GlobalConstants.StringLengthValidationMessage)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [StringLength(100, ErrorMessage = GlobalConstants.StringLengthValidationMessage)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [EmailAddress]
        public string Email { get; set; }

        public Gender Gender { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public string ProfilePicture { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"\b\d{3}[-.]?\d{3}[-.]?\d{4}\b", ErrorMessage = GlobalConstants.PhoneNumberValidationMessage)]
        public string PhoneNumber { get; set; }
    }
}