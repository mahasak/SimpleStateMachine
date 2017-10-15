using System;
using System.Collections.Generic;

namespace TestJournal.Lib
{
    public class TransitionList
    {
        private static readonly TransitionState completed = new TransitionState(HttpState.Complete, new Dictionary<string, HttpState>());

        private readonly Dictionary<HttpState, TransitionState> _states = new Dictionary<HttpState, TransitionState>();

        public TransitionState FirstNode => _states[HttpState.BeforeStart];

        public int Count { get { return _states.Count + 1; }}

        public bool ContainsState(HttpState state) 
        {
            return _states.ContainsKey(state);
        }

        public void Register(HttpState state, TransitionRoute[] transitionRoute)
        {
            if (_states.ContainsKey(state))
            { 
                throw new ArgumentException($"The state {state} has already registered.", nameof(state)); 
            }

            var routeDictionary = new Dictionary<string, HttpState>();

            foreach (var current in transitionRoute)
            {
                routeDictionary.Add(current.Route, current.State);
            }

            _states.Add(state, new TransitionState(state,routeDictionary));
        }

        public TransitionState Move(HttpState state, string direction)
        {
            var current = _states[state];

            var newState = current.Routes[direction];

            if (newState == HttpState.Complete)
            {
                return completed;
            }

            return _states[newState];
        }
    }
}
