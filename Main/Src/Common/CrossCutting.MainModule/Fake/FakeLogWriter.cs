using System;
using CrossCutting.Core.Logging;

namespace CrossCutting.MainModule.Fake
{
    public class FakeLogWriter : ILogWriter
    {
        public void Write(string message)
        {
            // Do nothing
        }

        public void Write(string message, Exception ex)
        {
            // Do nothing
        }
    }
}