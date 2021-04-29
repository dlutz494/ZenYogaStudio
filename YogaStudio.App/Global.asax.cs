using AutoMapper;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YogaStudio.App.Data;
using YogaStudio.App.Migrations;
using YogaStudio.App.Models.EntityModels;
using YogaStudio.App.Models.ViewModels;

namespace YogaStudio.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMaps();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<YogaStudioContext, Configuration>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<User, UserViewModel>();
                expression.CreateMap<Package, PackageViewModel>();
                expression.CreateMap<Address, AddressViewModel>();
                expression.CreateMap<User, UserViewModel>();
                expression.CreateMap<Order, MyOrderViewModel>();
                expression.CreateMap<Order, OrderViewModel>();
                expression.CreateMap<OrderPackage, OrderPackageViewModel>();
                expression.CreateMap<CreditCard, CreditCardViewModel>();
            });
        }
    }
}
