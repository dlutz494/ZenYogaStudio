[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(YogaStudio.App.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(YogaStudio.App.App_Start.NinjectWebCommon), "Stop")]

namespace YogaStudio.App.App_Start
{
    using System;
    using System.Web;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using YogaStudio.App.Data;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.EntityModels;
    using YogaStudio.App.Services.Implementations;
    using YogaStudio.App.Services.Interfaces;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IYogaStudioData>().To<YogaStudioData>()
               .InRequestScope()
               .WithConstructorArgument("context", p => new YogaStudioContext());

            kernel.Bind<IUserStore<User>>().To<UserStore<User>>()
                    .InRequestScope()
                    .WithConstructorArgument("context", kernel.Get<YogaStudioContext>());

            kernel.Bind<IAuthenticationManager>()
                    .ToMethod<IAuthenticationManager>(context => HttpContext.Current.GetOwinContext().Authentication)
                    .InRequestScope();

            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
        }
    }
}
