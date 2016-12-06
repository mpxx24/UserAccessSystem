using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace UserAccessSystem.Services {
    public class WindsorDependencyScope : IDependencyScope {
        private readonly IWindsorContainer container;
        private readonly IDisposable scope;

        public WindsorDependencyScope(IWindsorContainer container) {
            if (container == null) {
                throw new ArgumentNullException(nameof(container));
            }
            this.container = container;
            scope = container.BeginScope();
        }

        public void Dispose() {
            scope.Dispose();
        }

        public object GetService(Type serviceType) {
            return container.Kernel.HasComponent(serviceType) ? container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return container.ResolveAll(serviceType).Cast<object>().ToArray();
        }
    }
}