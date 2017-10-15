using System;
namespace TestJournal.Lib
{
    public class JournalEntry
    {
        public JournalEntry()
        {
            LogTime = DateTime.Now;
        }

        public DateTime LogTime {
            get;
            private set;
        }

        public String LogMessage {
            get;
            set;
        }

        public int? TimeTaken {
            get;
            set;
        }

        public DataItem[] DataCreated 
        {
            get;
            set;
        }

    }
}
