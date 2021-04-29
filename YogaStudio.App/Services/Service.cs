namespace YogaStudio.App.Services
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.EntityModels;

    public abstract class Service : Controller
    {
        protected Service(IYogaStudioData data)
        {
            this.Data = data;
        }

        protected Service(IYogaStudioData data, User user)
            : this(data)
        {
            this.UserProfile = user;
        }

        public IYogaStudioData Data { get; private set; }

        public User UserProfile { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}