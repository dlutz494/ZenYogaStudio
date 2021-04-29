namespace YogaStudio.App.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.EntityModels;

    public class HomeController : BaseAdminController
    {
        public HomeController(IYogaStudioData data)
            : base(data)
        {
        }

        public HomeController(IYogaStudioData data, User user)
            : base(data, user)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}