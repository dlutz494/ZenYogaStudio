namespace YogaStudio.App.Areas.Trainner.Controllers
{
    using System.Web.Mvc;
    using YogaStudio.App.Controllers;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.EntityModels;

    [Authorize(Roles = "Trainner")]
    [RouteArea("Trainner")]
    public class BaseTrainnerController : BaseController
    {
        public BaseTrainnerController(IYogaStudioData data)
            : base(data)
        {
        }

        public BaseTrainnerController(IYogaStudioData data, User user)
            : base(data, user)
        {
        }
    }
}