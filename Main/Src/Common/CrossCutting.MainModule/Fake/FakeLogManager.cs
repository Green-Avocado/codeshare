using System;
using CrossCutting.Core.Logging;

namespace CrossCutting.MainModule.Fake
{
    public class FakeLogManager : ILogManager
    {
        private IApplicationLogger _applicationLogger = new FakeApplicationLogger();

        public IApplicationLogger DefaultLogger
        {
            get { return _applicationLogger; }
        }
    }
}