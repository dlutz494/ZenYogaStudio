using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YogaStudio.App.Startup))]
namespace YogaStudio.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
