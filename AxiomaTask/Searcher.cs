using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxiomaTask.Dto;
using AxiomaTask.Models;
using AxiomaTask.ValueObjects;

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

            var func = ExpressionBuilder.GetExpression<Record>(new List<ParseResult>() { parser(query) });
            results = LogsCollection.LogsRecords.Where(func).ToArray();

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
