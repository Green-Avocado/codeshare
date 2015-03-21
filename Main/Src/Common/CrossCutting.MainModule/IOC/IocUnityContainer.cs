using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using CodeShare.Application;
using CodeShare.Data;
using CrossCutting.Core.IOC;
using CrossCutting.Core.Logging;
using CrossCutting.MainModule.Fake;
using CrossCutting.MainModule.Logging;
using Microsoft.Practices.Unity;

namespace CrossCutting.MainModule.IOC
{
    public class IocUnityContainer : IContainer
    {
        private static IUnityContainer _unityContainer;
        private static object _lockObject = new object();
        private static IocUnityContainer _container;

        private IocUnityContainer()
        {
            _unityContainer = new UnityContainer();
            RegisterTypes();
        }

        private IocUnityContainer(IUnityContainer container)
        {
            _unityContainer = container;
        }

        public static IocUnityContainer Instance
        {
            get
            {
                if (_container == null)
                {
                    lock (_lockObject)
                    {
                        _container = new IocUnityContainer();
                    }
                }

                return _container;
            }
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _unityContainer.Resolve(type);
        }

        public IEnumerable<object> ResolveAll(Type type)
        {
            return _unityContainer.ResolveAll(type);
        }

        public static void RegisterTypes()
        {
            bool realContainer = true;
            if (ConfigurationManager.AppSettings["IocRealContainer"] != null)
            {
                if (bool.TryParse(ConfigurationManager.AppSettings["IocRealContainer"], out realContainer) == false)
                {
                    realContainer = false;
                }
            }

            if (realContainer)
            {
                RegisterRealTypes();
            }
            else
            {
                RegisterFakeTypes();            
            }
        }

        private static void RegisterFakeTypes()
        {
            _unityContainer.RegisterType<ILogManager, FakeLogManager>();
            _unityContainer.RegisterType<IApplicationLogger, FakeApplicationLogger>();
            _unityContainer.RegisterType<ILogWriter, FakeLogWriter>();

            _unityContainer.RegisterType<IUnitOfWork, FakeUnitOfWork>();
        }

        private static void RegisterRealTypes()
        {
            _unityContainer.RegisterType<ILogManager, LogManager>();
            _unityContainer.RegisterType<IApplicationLogger, ApplicationLogger>();
            _unityContainer.RegisterType<ILogWriter, MelLogWriter>(new InjectionConstructor(TraceEventType.Information));

            _unityContainer.RegisterType<IProjectService, ProjectService>();
            _unityContainer.RegisterType<IUserService, UserService>();
            _unityContainer.RegisterType<IUnitOfWork, UnitOfWork>();
        }

        public IContainer CreateChildContainer()
        {
            var child = _unityContainer.CreateChildContainer();
            return new IocUnityContainer(child);
        }

        public void Dispose()
        {
            _unityContainer.Dispose();
        }
    }
}