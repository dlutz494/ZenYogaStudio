using System.ComponentModel;

namespace YogaStudio.App.Models.ViewModels
{
    public class CreditCardViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name on the card")]
        public string CardName { get; set; }

        [DisplayName("Card Number")]
        public string CardNumber { get; set; }

        [DisplayName("Expiry Date")]
        public string ExpiryDate { get; set; }

        [DisplayName("Security Code")]
        public string SecurityCode { get; set; }
    }
}