using System.ComponentModel;

namespace YogaStudio.App.Models.EntityModels
{
    public class Contact
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Address { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Support Email")]
        public string SupportEmail { get; set; }

        [DisplayName("Marketing Email")]
        public string MarketingEmail { get; set; }
    }
}