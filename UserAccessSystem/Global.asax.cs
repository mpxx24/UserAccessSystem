using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using UserAccessSystem.Services.Windsor;

namespace UserAccessSystem {
    public class WebApiApplication : HttpApplication {
        private static IWindsorContainer container;

        public override void Dispose() {
            container.Dispose();
            base.Dispose();
        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureWindsor(GlobalConfiguration.Configuration);
        }

        private static void ConfigureWindsor(HttpConfiguration configuration) {
            //windsor magic
            container = new WindsorContainer();
            container.Install(FromAssembly.This());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));

            //for Web API
            var dependencyResolver = new WindsorDependencyResolver(container);
            configuration.DependencyResolver = dependencyResolver;

            //for MVC
            var castleControllerFactory = new WindsorMvcControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(castleControllerFactory);
        }
    }
}