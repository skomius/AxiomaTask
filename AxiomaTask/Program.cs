// See https://aka.ms/new-console-template for more information
using AxiomaTask;
using CommandLine;
using Newtonsoft.Json;

string[] line = ["--help"];
while (true)
{
    Parser.Default.ParseArguments<SearchOptions, ImportOptions>(line)
    .MapResult((SearchOptions searchOpt) => Search(searchOpt), (ImportOptions addOptions) => ImportFile(addOptions), errs => 1);
    line = Console.ReadLine().SplitArgs(false);
}

int Search(SearchOptions searchOption)
{
    var searchResult = Searcher.Search(searchOption.Query, QParser.QueryParser);
    if (searchResult == null)
    {
        return 0;
    }

    Console.WriteLine(JsonConvert.SerializeObject(searchResult, Formatting.Indented));

    return 0;
}

int ImportFile(ImportOptions importOptions)
{
    FileImporter.ImportFile(importOptions.Path, importOptions.Severity);
    Console.WriteLine("File imported successfully");
    return 0;
}
