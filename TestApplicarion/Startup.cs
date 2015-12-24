using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestApplicarion.Startup))]
namespace TestApplicarion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
