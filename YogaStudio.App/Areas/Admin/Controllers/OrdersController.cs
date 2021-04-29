namespace YogaStudio.App.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.ViewModels;
    using YogaStudio.App.Services.Implementations;

    [RoutePrefix("orders")]
    public class OrdersController : BaseAdminController
    {
        private OrderService service;

        public OrdersController(IYogaStudioData data, OrderService service)
            : base(data)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            IEnumerable<OrderViewModel> viewModels = service.GetAllOrders();

            //int pageSize = 3;
            //int pageNumber = (page ?? 1);

            return View(viewModels);
        }

        public PartialViewResult _OrdersByStatusPartial(string status, int? page)
        {
            IEnumerable<OrderViewModel> viewModels = service.GetOrdersByStatus(status);

            //int pageSize = 3;
            //int pageNumber = (page ?? 1);

            return PartialView(viewModels);
        }

        [HttpGet]
        [Route("{id}/packages")]
        public ActionResult Packages(int id)
        {
            IEnumerable<OrderPackageViewModel> viewModels = service.DisplayOrderPackages(id);

            return View(viewModels);
        }

        [HttpGet]
        [Route("{id}/client")]
        public ActionResult Client(int id)
        {
            UserViewModel user = service.GetOrderOwner(id);

            return View(user);
        }
    }
}