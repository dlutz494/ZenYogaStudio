namespace YogaStudio.App.Services.Interfaces
{
    using System.Collections.Generic;
    using YogaStudio.App.Models.EntityModels;
    using YogaStudio.App.Models.ViewModels;

    public interface IOrderService
    {
        Package GetPackage(int id);
        Order GetOrder(User user);
        IEnumerable<OrderPackageViewModel> MyOrder(User user);
        Order GetCurrentOrder(int cartId);
        void AddToOrder(Order order, Package package);
        void RemoveFromOrder(Order order, Package package);
        void DecreaseGameUnitsFromOrder(Order order, Package package);
        void IncreaseGameUnitsFromOrder(Order order, Package package);
        void MakeAnOrder(int id, decimal totalAmount);
        bool IsProfileComplete(User user);
        IEnumerable<OrderPackage> GetOrderPackages(int id);
    }
}
