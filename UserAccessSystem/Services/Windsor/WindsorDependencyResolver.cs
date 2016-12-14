using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace UserAccessSystem.Services.Windsor {
    public class WindsorDependencyResolver : IDependencyResolver {
        private readonly IWindsorContainer container;

        public WindsorDependencyResolver(IWindsorContainer container) {
            if (container == null) {
                throw new ArgumentNullException(nameof(container));
            }
            this.container = container;
        }

        public object GetService(Type serviceType) {
            return this.container.Kernel.HasComponent(serviceType) ? this.container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return this.container.ResolveAll(serviceType).Cast<object>().ToArray();
        }

        public IDependencyScope BeginScope() {
            return new WindsorDependencyScope(this.container);
        }

        public void Dispose() {
        }
    }
}