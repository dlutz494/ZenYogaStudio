using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using YogaStudio.App.Data.UnitOfWork;
using YogaStudio.App.Models.EntityModels;
using YogaStudio.App.Models.Enums;
using YogaStudio.App.Models.ViewModels;
using YogaStudio.App.Services.Interfaces;

namespace YogaStudio.App.Services.Implementations
{
    public class OrderService : Service, IOrderService
    {
        public OrderService(IYogaStudioData data)
            : base(data)
        {
        }

        public OrderService(IYogaStudioData data, User user)
            : base(data, user)
        {
        }

        public Package GetPackage(int id)
        {
            var package = this.Data.Packages.Find(id);
            return package;
        }

        public Order GetOrder(User user)
        {
            Order order =
                this.Data.Orders.All()
                    .FirstOrDefault(s => s.StudentId == user.Id && s.Status == OrderStatus.Open);

            if (order == null)
            {
                order = new Order()
                {
                    StudentId = user.Id,
                    TotalPrice = 0.00m,
                    DateOfOrder = DateTime.Now
                };

                this.Data.Orders.Add(order);
                this.Data.SaveChanges();
            }

            return order;
        }

        public IEnumerable<OrderPackageViewModel> MyOrder(User user)
        {
            IEnumerable<OrderPackage> orders =
                this.Data.OrderPackages.All()
                    .Where(s => s.Order.StudentId == user.Id && s.Order.Status == OrderStatus.Open).ToList();

            IEnumerable<OrderPackageViewModel> viewModels = Mapper.Instance.Map<IEnumerable<OrderPackage>, IEnumerable<OrderPackageViewModel>>(orders);

            return viewModels;
        }

        public Order GetCurrentOrder(int cartId)
        {
            Order order = this.Data.Orders.Find(cartId);

            return order;
        }

        public void AddToOrder(Order order, Package package)
        {
            var games =
                this.Data.OrderPackages.All()
                .Where(sp => sp.OrderId == order.Id).Select(sp => sp.Package).ToList();

            OrderPackage orderGame =
                this.Data.OrderPackages.All()
                .FirstOrDefault(sp => sp.OrderId == order.Id && sp.PackageId == package.Id);

            if (games.Any())
            {
                foreach (var orderGames in games)
                {
                    if (orderGames.Id == package.Id)
                    {
                        if (orderGame != null) orderGame.Units++;
                        this.Data.SaveChanges();
                        return;
                    }
                }
            }

            var newOrderPackage = new OrderPackage()
            {
                OrderId = order.Id,
                PackageId = package.Id
            };

            this.Data.OrderPackages.Add(newOrderPackage);
            this.Data.SaveChanges();
        }

        public void RemoveFromOrder(Order order, Package package)
        {
            var orderPackage = this.Data.OrderPackages
                            .All()
                            .SingleOrDefault(mc => mc.OrderId == order.Id && mc.PackageId == package.Id);

            if (orderPackage != null)
            {
                this.Data.OrderPackages.Remove(orderPackage);
                this.Data.SaveChanges();
            }
        }

        public void DecreaseGameUnitsFromOrder(Order order, Package package)
        {
            var orderPackage =
                            this.Data.OrderPackages
                            .All()
                            .SingleOrDefault(mc => mc.OrderId == order.Id && mc.PackageId == package.Id);

            if (orderPackage != null)
            {
                orderPackage.Units -= 1;

                if (orderPackage.Units == 0)
                {
                    this.Data.OrderPackages.Remove(orderPackage);
                }
                this.Data.SaveChanges();
            }
        }

        public void IncreaseGameUnitsFromOrder(Order order, Package package)
        {
            var orderPackage =
                            this.Data.OrderPackages
                            .All()
                            .SingleOrDefault(mc => mc.OrderId == order.Id && mc.PackageId == package.Id);

            if (orderPackage != null)
            {
                orderPackage.Units += 1;
                this.Data.SaveChanges();
            }
        }

        public void MakeAnOrder(int id, decimal totalAmount)
        {
            Order order = this.Data.Orders.Find(id);
            order.Status = OrderStatus.Placed;
            order.TotalPrice = totalAmount;
            order.DateOfOrder = DateTime.Now;

            this.Data.SaveChanges();
        }

        public bool IsProfileComplete(User user)
        {
            if (user.FirstName == null || user.LastName == null || user.PhoneNumber == null)
            {
                return false;
            }

            return true;
        }

        public bool IsThereAnyCreditCard(User user)
        {
            return user.CreditCards.Any();
        }

        public IEnumerable<OrderPackage> GetOrderPackages(int id)
        {
            var packages =
                this.Data.OrderPackages.All()
                .Where(sp => sp.OrderId == id).ToList();

            return packages;
        }

        public IEnumerable<OrderPackageViewModel> DisplayOrderPackages(int id)
        {
            IEnumerable<OrderPackage> packages =
                this.Data.OrderPackages.All()
                .Where(sp => sp.OrderId == id).ToList();

            IEnumerable<OrderPackageViewModel> viewModels = Mapper.Instance.Map<IEnumerable<OrderPackage>, IEnumerable<OrderPackageViewModel>>(packages);

            return viewModels;
        }

        public IEnumerable<OrderViewModel> GetAllOrders()
        {
            IEnumerable<Order> orders = this.Data.Orders.All().OrderByDescending(o => o.DateOfOrder).ToList();
            foreach (var order in orders)
            {
                User user = this.Data.Users.Find(order.StudentId);
                order.Student = user;
            }
            IEnumerable<OrderViewModel> viewModels = Mapper.Instance.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders);

            return viewModels;
        }

        public IEnumerable<OrderViewModel> GetOrdersByStatus(string status)
        {
            IEnumerable<Order> orders;

            if (status == "All")
            {
                orders = this.Data.Orders.All().ToList();

            }
            else
            {
                OrderStatus currentStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), status);
                orders = this.Data.Orders.All().Where(s => s.Status == currentStatus).ToList();
            }

            IEnumerable<OrderViewModel> viewModels = Mapper.Instance.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders);

            return viewModels;
        }

        public UserViewModel GetOrderOwner(int id)
        {
            var userId = this.Data.Orders.Find(id).StudentId;
            User user = this.Data.Users.Find(userId);
            UserViewModel viewModel = Mapper.Instance.Map<User, UserViewModel>(user);

            return viewModel;
        }

        public void AddCreditCardToOrder(int orderId, int cardId)
        {
            Order order = this.Data.Orders.Find(orderId);
            if (order != null)
            {
                order.CreditCardId = cardId;
                this.Data.SaveChanges();
            }
        }

        public void RemoveCreditCardFromOrder(int orderId)
        {
            Order order = this.Data.Orders.Find(orderId);
            if (order != null)
            {
                order.CreditCardId = null;
                this.Data.SaveChanges();
            }
        }
    }
}