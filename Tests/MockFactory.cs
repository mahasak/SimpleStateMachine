using System;
namespace Tests
{
    public static class MockFactory
    {
        public static ContextMock ContextMocks => new ContextMock();
        public static TransitionListMock TransitionListMocks => new TransitionListMock();
    }
}
