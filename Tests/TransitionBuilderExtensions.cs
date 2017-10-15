using System;
using TestJournal.Lib;
using Moq;

namespace Tests
{
    public static class TransitionBuilderExtensions
    {
        public static TransitionList WithSimpleRouteOf(this TransitionList transitions, HttpState source, string defaultRoute, HttpState destination)
        {
            var transitionRoute = new TransitionRoute(defaultRoute, destination);
            var routes = new[] { transitionRoute };
            transitions.Register(source, routes);

            return transitions;
        }

        public static Mock<IPipelineActionCreator> ForceExecuteToReturn(this Mock<IPipelineActionCreator> instance, HttpState desired, string newRoute)
        {
            var pipelineAction = new Mock<HttpPipelineAction>();

            pipelineAction.Setup(p => p.Execute(It.IsAny<PipelineContext>(), It.IsAny<HttpContextBase>())).Returns(newRoute);

            instance.Setup(p => p.Create(It.Is<HttpState>(x => x == desired))).Returns(pipelineAction.Object);

            return instance;
        }
    }
}
