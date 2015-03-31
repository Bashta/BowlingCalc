using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BowlingCalc.Startup))]
namespace BowlingCalc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
