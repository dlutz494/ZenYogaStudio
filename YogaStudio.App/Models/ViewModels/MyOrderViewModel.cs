namespace YogaStudio.App.Models.ViewModels
{
    using System;
    using YogaStudio.App.Models.Enums;

    public class MyOrderViewModel
    {
        public int Id { get; set; }

        public DateTime? DateOfOrder { get; set; }

        public OrderStatus Status { get; set; }

        public PaymentType PaymentType { get; set; }

        public decimal TotalPrice { get; set; }
    }
}