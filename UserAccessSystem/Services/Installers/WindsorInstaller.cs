using System.Web.Http.Controllers;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UserAccessSystem.Repository;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Services.Installers {
    public class WindsorInstaller : IWindsorInstaller {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(
                Classes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient(),
                Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient()
                );

            container.Register(
                Component.For<IRepository>().ImplementedBy<Repository.Repository>(),
                Component.For<IUserService>().ImplementedBy<UserService>(),
                Component.For<ITerritoryService>().ImplementedBy<TerritoryService>()
                );
        }
    }
}