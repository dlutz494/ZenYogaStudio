namespace YogaStudio.App.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using YogaStudio.App.Controllers;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.EntityModels;

    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class BaseAdminController : BaseController
    {
        public BaseAdminController(IYogaStudioData data)
            : base(data)
        {
        }

        public BaseAdminController(IYogaStudioData data, User user)
            : base(data, user)
        {
        }
    }
}