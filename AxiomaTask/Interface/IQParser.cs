using AxiomaTask.ValueObjects;

namespace AxiomaTask.Interface
{
    public interface IQParser 
    {
        public ParseResult QueryParser(string query);
    }
}
