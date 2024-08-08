using CommandLine;
using CommandLine.Text;

namespace AxiomaTask
{
    [Verb("search", HelpText = "Search")]
    internal class SearchOptions
    {

        [Option('q', "query", Required = true, HelpText = "Search query")]
        public required string Query { get; set; }

        [Usage(ApplicationAlias = "")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>() { new Example("Convert file to a trendy format", new SearchOptions { Query = "Property='value'" })
            };
            }
        }
    }

    [Verb("import", HelpText = "Import file")]
    internal class ImportOptions
    {

        [Option('r', "read", Required = true, HelpText = "Path to file ready to import")]
        public required string Path { get; set; }

        [Usage(ApplicationAlias = "")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>() { new Example("Import log file", new SearchOptions { Query = "FileName" })
            };
            }
        }
    }
}
