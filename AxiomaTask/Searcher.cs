using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var results = LogsCollection.LogsRecords.Where(r => parserResult.Expr((string)typeof(Record).GetProperty(parserResult.Property)?.GetValue(r))).ToArray();

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
