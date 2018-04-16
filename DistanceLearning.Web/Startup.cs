using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DistanceLearning.Web.Startup))]
namespace DistanceLearning.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
