namespace YogaStudio.App.Models.EntityModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}