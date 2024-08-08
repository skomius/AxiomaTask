using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxiomaTask.Dto;
using AxiomaTask.Models;

namespace AxiomaTask
{
    static internal class Searcher
    {
        internal static SearchResult? Search(string query, Func<string, ParseResult> parser)
        {
            var parserResult = parser(query);

            if (parserResult == null)
            {
                throw new InvalidOperationException("Query parsing failed");
            }

            if (typeof(Record).GetProperty(parserResult.Property) == null)
            {
                Console.WriteLine("Property does not exist");
                return null;
            }

            Record[] results;

            if (parserResult.Value is string)
            {
                results = LogsCollection.LogsRecords.Where(r => parserResult.Expr((string)typeof(Record).GetProperty(parserResult.Property)?.GetValue(r))).ToArray();
            }
            else if (parserResult.Value is bool)
            {
                results = LogsCollection.LogsRecords.Where(r => (bool)typeof(Record).GetProperty(parserResult.Property)?.GetValue(r) == (bool)parserResult.Value).ToArray();
            }
            else
            {
                throw new NotImplementedException();
            }

            return
                new SearchResult
                {
                    SearchQuery = query,
                    Count = results.Count(),
                    Results = results
                };
        }
    }
}
