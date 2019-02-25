using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ReportServerIntegration {
    public class DefaultDependencyResolver : IDependencyResolver {
        readonly IServiceProvider serviceProvider;

        public DefaultDependencyResolver(IServiceProvider serviceProvider) {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public object GetService(Type serviceType) {
            return serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return serviceProvider.GetServices(serviceType);
        }
    }
}
