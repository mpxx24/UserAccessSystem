using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace UserAccessSystem.Services.Windsor {
    public class WindsorMvcControllerFactory : DefaultControllerFactory {
        public WindsorMvcControllerFactory(IWindsorContainer container) {
            if (container == null) {
                throw new ArgumentNullException(nameof(container));
            }
            this.Container = container;
        }
        public IWindsorContainer Container { get; protected set; }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
            if (controllerType == null) {
                return null;
            }
            return this.Container.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller) {
            var disposableController = controller as IDisposable;
            disposableController?.Dispose();

            this.Container.Release(controller);
        }
    }
}