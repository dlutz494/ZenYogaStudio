namespace YogaStudio.App.Services.Implementations
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.BindingModels;
    using YogaStudio.App.Models.EntityModels;
    using YogaStudio.App.Models.Enums;
    using YogaStudio.App.Models.ViewModels;
    using YogaStudio.App.Services.Interfaces;

    public class ProfileService : Service, IProfileService
    {
        public ProfileService(IYogaStudioData data)
            : base(data)
        {
        }

        public ProfileService(IYogaStudioData data, User user)
            : base(data, user)
        {
        }

        public UserViewModel GetProfile(User currentUser)
        {
            UserViewModel viewModel = Mapper.Instance.Map<User, UserViewModel>(currentUser);

            return viewModel;
        }

        public AddressViewModel GetMailingAddress(User currentUser)
        {
            var address = this.Data.Addresses.All().FirstOrDefault(a => a.UserId == currentUser.Id);
            AddressViewModel viewModel = Mapper.Instance.Map<Address, AddressViewModel>(address);

            return viewModel;
        }

        public IEnumerable<MyOrderViewModel> GetMyOrders(User user)
        {
            IEnumerable<Order> shoppingcarts =
                this.Data.Orders.All()
                    .Where(s => s.StudentId == user.Id)
                    .OrderByDescending(s => s.DateOfOrder)
                    .ToList();

            IEnumerable<MyOrderViewModel> viewModels = Mapper.Instance.Map<IEnumerable<Order>, IEnumerable<MyOrderViewModel>>(shoppingcarts);

            return viewModels;
        }

        public IEnumerable<MyOrderViewModel> GetOrdersByStatus(User user, string status)
        {
            IEnumerable<Order> orders;

            if (status == "All")
            {
                orders = this.Data.Orders.All().Where(s => s.StudentId == user.Id).ToList();

            }
            else
            {
                OrderStatus currentStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), status);
                orders = this.Data.Orders.All().Where(s => s.StudentId == user.Id && s.Status == currentStatus).ToList();
            }

            IEnumerable<MyOrderViewModel> viewModels = Mapper.Instance.Map<IEnumerable<Order>, IEnumerable<MyOrderViewModel>>(orders);

            return viewModels;
        }

        public void EditAddress(User user, AddressBindingModel model)
        {
            Address address =
                this.Data.Addresses.All()
                    .FirstOrDefault(s => s.UserId == user.Id);

            if (address == null)
            {
                address = new Address()
                {
                    Street = model.Street,
                    City = model.City,
                    PostalCode = model.PostalCode,
                    UserId = user.Id
                };

                this.Data.Addresses.Add(address);
                this.Data.SaveChanges();
            }
            else
            {
                address.Street = model.Street;
                address.City = model.City;
                address.PostalCode = model.PostalCode;
                this.Data.SaveChanges();
            }
        }

        public CreditCardViewModel GetCreditCard(User currentUser)
        {
            var creditCard = this.Data.CreditCards.All().FirstOrDefault(cc => cc.UserId == currentUser.Id);
            CreditCardViewModel viewModel = Mapper.Instance.Map<CreditCard, CreditCardViewModel>(creditCard);

            return viewModel;
        }

        public void EditCreditCard(User user, CreditCardBindingModel model)
        {
            CreditCard creditCard =
               this.Data.CreditCards.All()
                   .FirstOrDefault(cc => cc.UserId == user.Id);

            if (creditCard == null)
            {
                creditCard = new CreditCard()
                {
                    CardName = model.CardName,
                    CardNumber = model.CardNumber,
                    ExpiryDate = model.ExpiryDate,
                    SecurityCode = model.SecurityCode,
                    UserId = user.Id
                };

                this.Data.CreditCards.Add(creditCard);
                this.Data.SaveChanges();
            }
            else
            {
                creditCard.CardName = model.CardName;
                creditCard.CardNumber = model.CardNumber;
                creditCard.ExpiryDate = model.ExpiryDate;
                creditCard.SecurityCode = model.SecurityCode;
                this.Data.SaveChanges();
            }
        }

        public void EditUser(User user, UserBindingModel model)
        {
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Gender = model.Gender;
            user.Height = model.Height;
            user.Weight = model.Weight;
            user.ProfilePicture = model.ProfilePicture;
            user.PhoneNumber = model.PhoneNumber;

            this.Data.SaveChanges();
        }
    }
}