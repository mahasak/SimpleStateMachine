using System;
using System.Collections.Generic;

namespace TestJournal.Lib
{
    public class TransitionState
    {
        public TransitionState(HttpState state, IReadOnlyDictionary<string, HttpState> routes)
        {
            State = state;
            Routes = routes;
        }

        public HttpState State { get; }

        public IReadOnlyDictionary<string, HttpState> Routes { get; }

        public HttpState Move(string route) 
        {
            if (!Routes.ContainsKey(route))
            {
                throw new ArgumentOutOfRangeException(nameof(route), route, $"Invalid route {route} supplied for current state {this.State}");
            }

            return Routes[route];
        }
    }
}
