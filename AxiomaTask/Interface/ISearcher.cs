using AxiomaTask.Dto;
using AxiomaTask.ValueObjects;

namespace AxiomaTask.Interface
{
    public interface ISearcher
    {
        public SearchResult? Search(string query);
    }
}
