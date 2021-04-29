namespace YogaStudio.App.Models.ViewModels
{
    using System.Collections.Generic;
    using YogaStudio.App.Models.EntityModels;

    public class OrderPackageViewModel
    {
        public OrderPackageViewModel()
        {
            this.CreditCards = new HashSet<CreditCard>();
        }

        public int OrderId { get; set; }

        public int PackageId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Package Package { get; set; }

        public int Units { get; set; }

        public ICollection<CreditCard> CreditCards { get; set; }
    }
}