namespace YogaStudio.App.Services.Interfaces
{
    using System.Collections.Generic;
    using YogaStudio.App.Models.BindingModels;
    using YogaStudio.App.Models.ViewModels;

    public interface ICreditCardService
    {
        IEnumerable<CreditCardViewModel> GetAllCreditCards(string userId);
        void CreateNewCreditCard(CreditCardBindingModel model, string userId);
        CreditCardViewModel GetEditCreditCard(int? id);
        void EditCreditCard(CreditCardBindingModel model);
        CreditCardViewModel GetDeleteCreditCard(int? id);
        void DeleteCreditCard(int id);
    }
}
