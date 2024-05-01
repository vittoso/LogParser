
namespace LogParser.Engine
{

    internal interface IFileParser
    {
        void Parse(FileInfo fileInfo, Action<Event> callBack);
    }


}
