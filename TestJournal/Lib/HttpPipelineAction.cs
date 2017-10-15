using System;
namespace TestJournal.Lib
{
    public abstract class HttpPipelineAction
    {
        public const string NEXT = "next";

        public virtual string Execute(PipelineContext context, HttpContextBase webContext)
        {
            return NEXT;
        }
    }
}
