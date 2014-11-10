using System;
using CrossCutting.Core.Logging;

namespace CrossCutting.MainModule.Fake
{
    public class FakeLogWriter : ILogWriter
    {
        public void Write(string message)
        {
        }

        public void Write(string message, Exception ex)
        {
        }
    }
}