namespace YogaStudio.App.Services.Implementations
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.BindingModels;
    using YogaStudio.App.Models.EntityModels;
    using YogaStudio.App.Models.ViewModels;
    using YogaStudio.App.Services.Interfaces;

    public class CreditCardService : Service, ICreditCardService
    {
        public CreditCardService(IYogaStudioData data)
            : base(data)
        {
        }

        public CreditCardService(IYogaStudioData data, User user)
            : base(data, user)
        {
        }

        public IEnumerable<CreditCardViewModel> GetAllCreditCards(string userId)
        {
            IEnumerable<CreditCard> creditCards = this.Data.CreditCards.All().Where(c => c.UserId == userId).OrderBy(c => c.Id);
            IEnumerable<CreditCardViewModel> viewModels = Mapper.Instance.Map<IEnumerable<CreditCard>, IEnumerable<CreditCardViewModel>>(creditCards);

            return viewModels;
        }

        public void CreateNewCreditCard(CreditCardBindingModel model, string userId)
        {
            CreditCard existingCreditCard = this.Data.CreditCards.All().FirstOrDefault(c => c.CardNumber == model.CardNumber);

            if (existingCreditCard == null)
            {
                var creditCard = new CreditCard()
                {
                    CardName = model.CardName,
                    CardNumber = model.CardNumber,
                    ExpiryDate = model.ExpiryDate,
                    SecurityCode = model.SecurityCode,
                    UserId = userId
                };

                this.Data.CreditCards.Add(creditCard);
            }

            this.Data.SaveChanges();
        }

        public CreditCardViewModel GetEditCreditCard(int? id)
        {
            CreditCard creditCard = this.Data.CreditCards.Find(id);

            if (creditCard == null)
            {
                return null;
            }

            CreditCardViewModel viewModel = Mapper.Instance.Map<CreditCard, CreditCardViewModel>(creditCard);

            return viewModel;
        }

        public void EditCreditCard(CreditCardBindingModel model)
        {
            CreditCard creditCard = this.Data.CreditCards.Find(model.Id);

            if (creditCard != null)
            {
                creditCard.CardName = model.CardName;
                creditCard.CardNumber = model.CardNumber;
                creditCard.ExpiryDate = model.ExpiryDate;
                creditCard.SecurityCode = model.SecurityCode;

                this.Data.SaveChanges();
            }
        }

        public CreditCardViewModel GetDeleteCreditCard(int? id)
        {
            CreditCard creditCard = this.Data.CreditCards.Find(id);

            if (creditCard == null)
            {
                return null;
            }

            CreditCardViewModel viewModel = Mapper.Instance.Map<CreditCard, CreditCardViewModel>(creditCard);

            return viewModel;
        }

        public void DeleteCreditCard(int id)
        {
            CreditCard creditCard = this.Data.CreditCards.Find(id);
            if (creditCard == null) return;
            this.Data.CreditCards.Remove(creditCard);
            this.Data.SaveChanges();
        }
    }
}