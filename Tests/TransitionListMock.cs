using Moq;
using System;
using TestJournal.Lib;

namespace Tests
{
    public class TransitionListMock : MockProviderBase<IPipelineActionCreator>
    {
        public TransitionList CreateDefaultTransitionList()
        {
            var list = new TransitionList();
            return list;
        }

        public override Mock<IPipelineActionCreator> CreateDefault()
        {
            var mocked = base.CreateDefault();

            mocked.Setup(p=>p.Create(It.IsAny<HttpState>())).Returns(new DummyMock(HttpPipelineAction.NEXT));

            return mocked;
        }

        public class DummyMock : HttpPipelineAction 
        {
            private readonly string _target;

            public DummyMock(string target)
            {
                _target = target;
            }

            public override string Execute(PipelineContext context, HttpContextBase webContext)
            {
                return _target;
            }
        }
    }
}
