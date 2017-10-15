using System;
using System.Collections.Generic;

namespace TestJournal.Lib
{
    public class PipelineJournal
    {
        private List<JournalEntry> _entries = new List<JournalEntry>();

        public void LogStateChange(HttpState oldState, HttpState currentState, string direction)
        {
            var entry = new JournalEntry()
            {
                LogMessage = $"State has changed from {oldState} to {currentState}, using the route {direction}"
            };

            _entries.Add(entry);
        }

        public void LogActionComplete(HttpState currentState, string activity, int elapsedMilliseconds, string direction)
        {
            var entry = new JournalEntry()
            {
                LogMessage = $"{currentState}: Activity {activity} completed successfully, route selected {direction}",
                TimeTaken = elapsedMilliseconds
            };

            _entries.Add(entry);
        }

    }
}
