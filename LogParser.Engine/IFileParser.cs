
namespace LogParser.Engine
{

    internal interface IFileParser
    {
        Task Parse(FileInfo fileInfo, CancellationToken token, Action<Event> callBack);
    }


}
