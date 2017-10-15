using System;
namespace TestJournal.Lib
{
    public interface IPipelineActionCreator
    {
        HttpPipelineAction Create(HttpState state);
    }
}
