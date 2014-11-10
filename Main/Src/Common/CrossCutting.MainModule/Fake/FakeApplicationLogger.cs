using System;
using CrossCutting.Core.Logging;

namespace CrossCutting.MainModule.Fake
{
    public class FakeApplicationLogger : IApplicationLogger
    {
        private ILogWriter _logWriter = new FakeLogWriter();

        public ILogWriter Critical
        {
            get { return _logWriter; }
        }

        public ILogWriter Error
        {
            get { return _logWriter; }
        }

        public ILogWriter Warning
        {
            get { return _logWriter; }
        }

        public ILogWriter Information
        {
            get { return _logWriter; }
        }

        public string Name
        {
            get { return "Fake Log Writer"; }
        }
    }
}