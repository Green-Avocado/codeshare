using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using CrossCutting.Core.IOC;

namespace CodeShare.Api
{
    public class UnityResolver : IDependencyResolver
    {
        private IContainer _container;

        public UnityResolver(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new UnityResolver(_container.CreateChildContainer());
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}