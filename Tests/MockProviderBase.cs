using Moq;
using System;
namespace Tests
{
    public abstract class MockProviderBase<T> where T : class
    {
        private readonly Mock<T> _mocked = new Mock<T>();

        public virtual Mock<T> CreateDefault()
        {
            return _mocked;
        }

        protected Mock<T> Mocked => _mocked;
    }
}
