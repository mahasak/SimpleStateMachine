using System;
using System.Diagnostics;

namespace TestJournal.Lib
{
    public class HttpStateMachine
    {

        private readonly TransitionList _overrides;

        private readonly IPipelineActionCreator _creator;

        public HttpStateMachine(TransitionList overrides, IPipelineActionCreator creator)
        {
            _overrides = overrides;
            _creator = creator;
        }

        public HttpStateMachine(IPipelineActionCreator creator) : this(null, creator) { }

        public void Traverse(HttpContextBase webContext)
        {
            var context = new PipelineContext();
            var table = (_overrides == null) ? new TransitionTable(_creator) : new TransitionTable(_overrides, _creator);

            var direction = HttpPipelineAction.NEXT;

            do
            {
                var oldState = table.CurrentState;
                var action = table.Move(direction);
                context.Journal.LogStateChange(oldState, table.CurrentState, direction);

                var w = Stopwatch.StartNew();
                direction = action.Execute(context, webContext);
                w.Stop();

                context.Journal.LogActionComplete(table.CurrentState, action.GetType().Name, (int)w.Elapsed.TotalMilliseconds, direction);
            } while (!table.IsComplete);
        }
    }
}
