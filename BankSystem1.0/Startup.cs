using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankSystem1._0.Startup))]
namespace BankSystem1._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
