namespace YogaStudio.App.Services.Interfaces
{
    using System.Collections.Generic;
    using YogaStudio.App.Models.BindingModels;
    using YogaStudio.App.Models.EntityModels;
    using YogaStudio.App.Models.ViewModels;

    public interface IProfileService
    {
        UserViewModel GetProfile(User user);
        IEnumerable<MyOrderViewModel> GetMyOrders(User user);
        IEnumerable<MyOrderViewModel> GetOrdersByStatus(User user, string status);
        void EditUser(User user, UserBindingModel model);
    }
}
