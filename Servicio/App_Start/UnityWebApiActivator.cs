using System.Web.Http;
using Microsoft.Practices.Unity.WebApi;
using System;
using System.Diagnostics;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Servicio.App_Start.UnityWebApiActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Servicio.App_Start.UnityWebApiActivator), "Shutdown")]

namespace Servicio.App_Start
{
    /// <summary>Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET</summary>
    public static class UnityWebApiActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start()
        {

            try
            {

                // Use UnityHierarchicalDependencyResolver if you want to use a new child container for each IHttpController resolution.

                var resolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());

                GlobalConfiguration.Configuration.DependencyResolver = resolver;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}
