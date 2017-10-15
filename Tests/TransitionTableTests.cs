using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TestJournal.Lib;

namespace Tests
{
    [TestClass]
    public class TransitionTableTest
    {
        public static TransitionList CreateBasicList()
        {
            var list = MockFactory.TransitionListMocks.CreateDefaultTransitionList()
                                  .WithSimpleRouteOf(HttpState.BeforeStart, HttpPipelineAction.NEXT, HttpState.Initialcheck)
                                  .WithSimpleRouteOf(HttpState.Initialcheck, HttpPipelineAction.NEXT, HttpState.Complete);

            return list;
        }

        public static IPipelineActionCreator CreateCreator()
        {
            var creator = MockFactory.TransitionListMocks.CreateDefault();
            return creator.Object;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var list = MockFactory.TransitionListMocks.CreateDefaultTransitionList()
                                  .WithSimpleRouteOf(HttpState.BeforeStart, HttpPipelineAction.NEXT, HttpState.Complete);

            var tt = new TransitionTable(list, CreateCreator());

            Assert.IsFalse(tt.IsComplete);
            tt.Move(HttpPipelineAction.NEXT);

            Assert.IsTrue(tt.IsComplete);
        }
    }
}
