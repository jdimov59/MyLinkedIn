using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyLinkedIn.Web.Startup))]
namespace MyLinkedIn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
