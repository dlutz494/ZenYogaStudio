namespace YogaStudio.App.Controllers
{
    using System.Web.Mvc;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.EntityModels;

    public class HomeController : BaseController
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

        public ActionResult About()
        {
            About about = this.Data.Abouts.Find(1);

            return View(about);
        }

        public ActionResult Contact()
        {
            Contact contact = this.Data.Contact.Find(1);

            return View(contact);
        }
    }
}