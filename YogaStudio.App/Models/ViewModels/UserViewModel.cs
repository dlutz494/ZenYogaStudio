namespace YogaStudio.App.Models.ViewModels
{
    using System;
    using System.ComponentModel;
    using YogaStudio.App.Models.Enums;

    public class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public double? Weight { get; set; }

        public double? Height { get; set; }

        public string Referral { get; set; }

        public string Description { get; set; }

        [DisplayName("Profile Picture")]
        public string ProfilePicture { get; set; }

        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}