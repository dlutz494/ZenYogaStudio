namespace YogaStudio.App.Areas.Trainner.Controllers
{
    using System.Web.Mvc;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.EntityModels;

    public class HomeController : BaseTrainnerController
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