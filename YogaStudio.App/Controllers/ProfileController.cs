namespace YogaStudio.App.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.BindingModels;
    using YogaStudio.App.Models.EntityModels;
    using YogaStudio.App.Models.ViewModels;
    using YogaStudio.App.Services.Implementations;

    public class ProfileController : BaseController
    {
        private ProfileService service;

        public ProfileController(IYogaStudioData data, ProfileService service, User user)
            : base(data, user)
        {
            this.service = service;
        }

        public ProfileController(IYogaStudioData data, User user)
            : base(data, user)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            UserViewModel viewModel = service.GetProfile(this.UserProfile);

            TempData["controllerName"] = this.ControllerContext.RouteData.Values["controller"].ToString();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            UserViewModel viewModel = service.GetProfile(this.UserProfile);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserBindingModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                service.EditUser(this.UserProfile, model);

                string controller = TempData["controllerName"].ToString();

                return RedirectToAction("Index", controller, routeValues: new { area = "" });

            }

            return this.View();
        }

        [HttpGet]
        public ActionResult MailingAddress()
        {
            AddressViewModel viewModel = service.GetMailingAddress(this.UserProfile);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MailingAddress(AddressBindingModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                service.EditAddress(this.UserProfile, model);
            }

            return RedirectToAction("Index", "Profile", routeValues: new { area = "" });
        }

        [HttpGet]
        public ActionResult CreditCard()
        {
            CreditCardViewModel viewModel = service.GetCreditCard(this.UserProfile);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreditCard(CreditCardBindingModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                service.EditCreditCard(this.UserProfile, model);
                return RedirectToAction("Index", "Profile", routeValues: new { area = "" });
            }

            return View();
        }

        [HttpGet]
        public ActionResult MyOrders(int? page)
        {
            IEnumerable<MyOrderViewModel> viewModels = service.GetMyOrders(this.UserProfile);

            //int pageSize = 3;
            //int pageNumber = (page ?? 1);

            return View(viewModels);
        }

        [HttpGet]
        public PartialViewResult _OrdersByStatusPartial(string status, int? page)
        {
            IEnumerable<MyOrderViewModel> viewModels = service.GetOrdersByStatus(this.UserProfile, status);

            //int pageSize = 3;
            //int pageNumber = (page ?? 1);

            return PartialView(viewModels);
        }
    }
}