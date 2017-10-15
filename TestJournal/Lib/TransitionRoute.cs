using System;
namespace TestJournal.Lib
{
    public class TransitionRoute
    {
        public string Route { get; private set; }

        public HttpState State { get; private set; }

        public TransitionRoute(string route, HttpState state)
        {
            Route = route;
            State = state;
        }
    }
}
