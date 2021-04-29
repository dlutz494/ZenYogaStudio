using System.Collections.Generic;
using System.Web.Mvc;
using YogaStudio.App.Data.UnitOfWork;
using YogaStudio.App.Models.EntityModels;
using YogaStudio.App.Models.ViewModels;
using YogaStudio.App.Services.Implementations;

namespace YogaStudio.App.Controllers
{
    public class PackagesController : BaseController
    {
        private readonly PackagesService service;

        public PackagesController(IYogaStudioData data, PackagesService service, User user)
            : base(data, user)
        {
            this.service = service;
        }

        // GET: Package
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<PackageViewModel> packages = this.service.GetAllPackages();

            return View(packages);
        }

        public ActionResult Details(int packageId)
        {
            PackageViewModel package = this.service.PackageDetails(packageId);

            return this.View(package);
        }
    }
}