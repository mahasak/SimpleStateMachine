using System;
namespace TestJournal.Lib
{
    public enum HttpState
    {
        BeforeStart = 0,
        Initialcheck = 1,
        UrlMapping = 2,
        Complete = 99
    }
}
