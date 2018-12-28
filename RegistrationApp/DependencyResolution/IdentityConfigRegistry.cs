using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using RegistrationApp.Models;
using SendGrid;
using StructureMap.Configuration.DSL;
using System.Configuration;
using System.Data.Entity;
using System.Net;
using System.Web;

namespace RegistrationApp.DependencyResolution
{
    public class IdentityConfigRegistry : Registry
    {
        public IdentityConfigRegistry()
        {
            For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>();
            For<DbContext>().Use(() => new ApplicationDbContext());
            For<IAuthenticationManager>().Use(ctx => HttpContext.Current.GetOwinContext().Authentication);

            var networkCredential = new NetworkCredential(
                    ConfigurationManager.AppSettings["mailAccount"],
                    ConfigurationManager.AppSettings["mailPassword"]);
            For<NetworkCredential>().Use(networkCredential);
            For<ITransport>().Use<Web>(); // .Ctor<NetworkCredential>().Is(networkCredential);
        }
    }
}