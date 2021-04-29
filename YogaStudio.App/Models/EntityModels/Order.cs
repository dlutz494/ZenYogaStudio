namespace YogaStudio.App.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using YogaStudio.App.Models.Enums;

    public class Order
    {
        public Order()
        {
            this.OrderPackages = new HashSet<OrderPackage>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime? DateOfOrder { get; set; }

        public OrderStatus Status { get; set; }

        public PaymentType PaymentType { get; set; }

        public decimal TotalPrice { get; set; }

        [Required]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }

        public int? CreditCardId { get; set; }

        public CreditCard CreditCard { get; set; }

        public virtual ICollection<OrderPackage> OrderPackages { get; set; }
    }
}