using System;
namespace TestJournal.Lib
{
    public class PipelineContext
    {
        public PipelineContext()
        {
            Journal = new PipelineJournal();
        }

        public PipelineJournal Journal { get; set; }
    }
}
