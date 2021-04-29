namespace YogaStudio.App.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreditCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CardName { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string ExpiryDate { get; set; }

        [Required]
        public string SecurityCode { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}