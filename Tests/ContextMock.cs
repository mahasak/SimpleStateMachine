using Moq;
using System;
using System.Collections.Generic;
using TestJournal.Lib;

namespace Tests
{
    public class ContextMock : MockProviderBase<HttpContextBase>
    {
        public override Mock<HttpContextBase> CreateDefault()
        {
            var itemDictionary = new Dictionary<string, object>();

            Mocked.SetupGet(p => p.Items).Returns(itemDictionary);

            return Mocked;
        }
    }
}
