using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistrationApp.Startup))]
namespace RegistrationApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app, ApplicationUserManager applicationUserManager, ApplicationSignInManager applicationSignInManager)
        {
            ConfigureAuth(app, applicationUserManager, applicationSignInManager);
        }
    }
}
