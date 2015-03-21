namespace CrossCutting.Core.IOC
{
    using System;
    using System.Collections.Generic;

    public interface IContainer
    {
        T Resolve<T>();

        object Resolve(Type type);

        IEnumerable<object> ResolveAll(Type type);

        IContainer CreateChildContainer();

        void Dispose();
    }
}