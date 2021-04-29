namespace YogaStudio.App.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.EntityModels;
    using YogaStudio.App.Models.ViewModels;
    using YogaStudio.App.Services.Implementations;

    [RoutePrefix("orders")]
    public class OrdersController : BaseController
    {
        private OrderService service;
        private ProfileService userService;
        private readonly CreditCardService creditCardService;

        public OrdersController(IYogaStudioData data, OrderService service, ProfileService userService, CreditCardService creditCardService)
            : base(data)
        {
            this.service = service;
            this.userService = userService;
            this.creditCardService = creditCardService;
        }

        public OrdersController(IYogaStudioData data, User user)
            : base(data, user)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (!service.IsProfileComplete(this.UserProfile))
            {
                TempData["controllerName"] = this.ControllerContext.RouteData.Values["controller"].ToString();
                return this.RedirectToAction("Edit", "Profile");
            }

            if (!service.IsThereAnyCreditCard(this.UserProfile))
            {
                TempData["controllerName"] = this.ControllerContext.RouteData.Values["controller"].ToString();
                return this.RedirectToAction("Index", "CreditCard");
            }

            IEnumerable<OrderPackageViewModel> orders = service.MyOrder(this.UserProfile);

            IEnumerable<CreditCardViewModel> creditCards = creditCardService.GetAllCreditCards(this.UserProfile.Id);

            OrderFullViewModel viewModel = new OrderFullViewModel()
            {
                OrderPackageViewModels = orders,
                CreditCardViewModels = creditCards
            };

            return View(viewModel);
        }

        [HttpGet]
        [Route("addpackage/{id}")]
        public ActionResult AddPackage(int id)
        {
            Package package = service.GetPackage(id);

            Order order = service.GetOrder(this.UserProfile);

            service.AddToOrder(order, package);

            return this.RedirectToAction("Index", "Packages");
        }

        [HttpGet]
        [Route("cart/{cartId}/removepackage/{id}")]
        public ActionResult RemovePackage(int cartId, int id)
        {
            Package package = service.GetPackage(id);

            Order order = service.GetCurrentOrder(cartId);

            service.RemoveFromOrder(order, package);

            IEnumerable<OrderPackageViewModel> orders = service.MyOrder(this.UserProfile);

            return this.RedirectToAction("Index", "Orders");
        }

       


        [HttpGet]
        [Route("placeorder/{id}")]
        public ActionResult PlaceOrder(int id, decimal totalAmount)
        {
            if (!service.IsProfileComplete(this.UserProfile))
            {
                UserViewModel viewModel = userService.GetProfile(this.UserProfile);
                return this.PartialView("_EditProfilePartial", viewModel);
            }

            service.MakeAnOrder(id, totalAmount);

            IEnumerable<OrderPackageViewModel> orders = service.MyOrder(this.UserProfile);

            return this.RedirectToAction("Index", "Orders");
        }

        [HttpGet]
        public ActionResult Packages(int id)
        {
            IEnumerable<OrderPackage> viewModels = service.GetOrderPackages(id);

            return View(viewModels);
        }

        public ActionResult AddCreditCardToOrder(int cardId, int orderId)
        {
            if (cardId > 0 && orderId > 0)
            {
                service.AddCreditCardToOrder(orderId, cardId);
            }
            return null;
        }

        public ActionResult RemoveCreditCardFromOrder(int orderId)
        {
            if (orderId > 0)
            {
                service.RemoveCreditCardFromOrder(orderId);
            }
            return null;
        }

    }
}