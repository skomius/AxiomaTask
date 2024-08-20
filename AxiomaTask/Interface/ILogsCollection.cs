using AxiomaTask.Models;

namespace AxiomaTask.Interface
{
    public interface ILogsCollection
    {
        public List<Record> LogsRecords { get; set; }
    }
}
