namespace YogaStudio.App.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using YogaStudio.App.Models.EntityModels;
    using YogaStudio.App.Models.Enums;

    public class OrderViewModel
    {
        public OrderViewModel()
        {
            this.Owner = new User();
            this.Packages = new HashSet<Package>();
        }

        public int Id { get; set; }

        public OrderStatus Status { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999.99, ErrorMessage = GlobalConstants.TotalPriceValidationMessage)]
        public decimal TotalPrice { get; set; }

        public DateTime? DateOfOrder { get; set; }

        public User Owner { get; set; }

        public ICollection<Package> Packages { get; set; }

        public int CreditCardId { get; set; }
    }
}