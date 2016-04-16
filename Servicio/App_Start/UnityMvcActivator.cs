using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.Diagnostics;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Servicio.App_Start.UnityWebActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Servicio.App_Start.UnityWebActivator), "Shutdown")]

namespace Servicio.App_Start
{
    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
    public static class UnityWebActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start()
        {
            try
            {
                var container = UnityConfig.GetConfiguredContainer();

                FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
                FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

                DependencyResolver.SetResolver(new UnityDependencyResolver(container));

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