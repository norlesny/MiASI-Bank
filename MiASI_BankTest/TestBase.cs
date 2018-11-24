using System;

namespace MiASI_BankTest
{
    public abstract class TestsBase : IDisposable
    {
        protected TestsBase()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}