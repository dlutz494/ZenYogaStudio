namespace YogaStudio.App.Models.ViewModels
{

    using System.Collections.Generic;

    public class OrderFullViewModel
    {
        public OrderFullViewModel()
        {
            CreditCardViewModels = new HashSet<CreditCardViewModel>();
            OrderPackageViewModels = new HashSet<OrderPackageViewModel>();
        }

        public IEnumerable<OrderPackageViewModel> OrderPackageViewModels { get; set; }

        public IEnumerable<CreditCardViewModel> CreditCardViewModels { get; set; }
    }
}