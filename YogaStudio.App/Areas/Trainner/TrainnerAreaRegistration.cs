using System.Web.Mvc;

namespace YogaStudio.App.Areas.Trainner
{
    public class TrainnerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Trainner";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.LowercaseUrls = true;
            context.Routes.MapMvcAttributeRoutes();

            context.MapRoute(
                "Trainner_default",
                "Trainner/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "YogaStudio.App.Areas.Trainner.Controllers" }
            );
        }
    }
}