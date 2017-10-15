using System;
namespace TestJournal.Lib
{
    public class TransitionTable
    {
        private readonly TransitionList _map;

        private TransitionState _current;

        private readonly IPipelineActionCreator _creator;

        public TransitionTable(TransitionList overrides, IPipelineActionCreator creator)
        {
            if (overrides == null)
            {
                throw new ArgumentNullException(nameof(overrides), $"Parameter TransitionList is null");
            }

            _creator = creator;

            _map = overrides;

            if(!_map.ContainsState(HttpState.BeforeStart))
            {
                _map.Register(HttpState.BeforeStart, new[] { new TransitionRoute(HttpPipelineAction.NEXT, HttpState.Initialcheck)});
            }

            _current = _map.FirstNode;
        }

        public int States => _map.Count;

        public HttpPipelineAction Begin()
        {
            return this.Move(HttpPipelineAction.NEXT);
        }

        public TransitionTable(IPipelineActionCreator creator) : this(CreateDefaultRoutes(), creator)
        {
            
        }

        public HttpState CurrentState => _current.State;

        public bool IsComplete => _current.State == HttpState.Complete;

        public HttpPipelineAction Move(string direction)
        {
            if(!_current.Routes.ContainsKey(direction))
            {
                throw new ArgumentOutOfRangeException(nameof(direction), direction, $"Invalid route for state {_current.State}. {direction} is out of list value");
            }

            var newState = _map.Move(_current.State, direction);

            var action = _creator.Create(newState.State);

            _current = newState;

            return action;
        }

        private static TransitionList CreateDefaultRoutes()
        {
            var list = new TransitionList();

            list.Register(HttpState.BeforeStart, new[] {new TransitionRoute(HttpPipelineAction.NEXT, HttpState.Initialcheck)});

            return list;
        }
    }
}
