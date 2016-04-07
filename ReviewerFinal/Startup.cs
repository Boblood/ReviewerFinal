using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReviewerFinal.Startup))]
namespace ReviewerFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
