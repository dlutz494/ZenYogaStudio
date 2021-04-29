namespace YogaStudio.App.Models.EntityModels
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using YogaStudio.App.Models.Enums;

    public class User : IdentityUser
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
            this.Packages = new HashSet<Package>();
            this.CreditCards = new HashSet<CreditCard>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public double? Weight { get; set; }

        public double? Height { get; set; }

        public SocialMedia? HowdoYouKnowAboutUs { get; set; }

        public string Referral { get; set; }

        public string Description { get; set; }

        public string ProfilePicture { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Package> Packages { get; set; }

        public virtual ICollection<CreditCard> CreditCards { get; set; }

        public virtual ICollection<TrainnerAvailability> TrainnerAvailabilities { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}