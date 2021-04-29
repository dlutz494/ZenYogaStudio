namespace YogaStudio.App.Areas.Admin.Controllers
{
    using AutoMapper;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using YogaStudio.App.Data;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.EntityModels;
    using YogaStudio.App.Models.ViewModels;
    using YogaStudio.App.Services.Implementations;

    [RoutePrefix("changerole")]
    public class ChangeRoleController : BaseAdminController
    {
        private readonly UserService service;
        private YogaStudioContext context = new YogaStudioContext();

        public ChangeRoleController(IYogaStudioData data, User user, UserService service)
            : base(data, user)
        {
            this.service = service;
        }

        // GET: Admin/ChangeRole
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("search")]
        public ActionResult Search(string currentFilter, string userName, int? page)
        {
            if (userName != null)
            {
                page = 1;
            }
            else
            {
                userName = currentFilter;

            }

            ViewBag.CurrentFilter = userName;

            if (userName == "")
            {
                return this.View();
            }

            var users = this.service.GetSearchedUsers(userName);

            return this.View(users);
        }

        public ActionResult MakeTrainner(string userId, int? page)
        {
            var store = new UserStore<User>(this.context);
            var manager = new UserManager<User>(store);

            manager.AddToRole(userId, "Trainner");

            return RedirectToAction("Index");
        }
    }
}