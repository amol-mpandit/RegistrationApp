// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace RegistrationApp.DependencyResolution {
    using ENotification;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using RegistrationApp.Models;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System.Configuration;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Web;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.AssemblyContainingType<Dll>();
                });
            //For<IExample>().Use<Example>();
            For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>();
            For<DbContext>().Use(() => new ApplicationDbContext());
            For<IAuthenticationManager>().Use(ctx => HttpContext.Current.GetOwinContext().Authentication);
            var networkCredential = new NetworkCredential(
                    ConfigurationManager.AppSettings["mailAccount"],
                    ConfigurationManager.AppSettings["mailPassword"]);
            For<NetworkCredential>().Use(networkCredential);
            var enotificationService = new EnotificationService(networkCredential);
            For<EnotificationService>().Use(enotificationService);
            For<IIdentityMessageService>().Use(new EmailService(enotificationService));
        }

        #endregion
    }
}