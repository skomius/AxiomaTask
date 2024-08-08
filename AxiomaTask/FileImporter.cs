using AxiomaTask.Dto;
using AxiomaTask.Models;
using CsvHelper;
using Newtonsoft.Json;
using System.Globalization;

namespace AxiomaTask
{
    internal class FileImporter
    {
        static internal void ImportFile(IEnumerable<string> paths, int minSeverity = int.MaxValue)
        {
            foreach (var path in paths)
            {
                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<Record>();
                        LogsCollection.LogsRecords.Add(record);

                        if (record.severity <= minSeverity)
                        {
                            Console.WriteLine(JsonConvert.SerializeObject(record, Formatting.Indented));
                        }
                    }
                }
            }

            LogsCollection.LogsRecords = LogsCollection.LogsRecords.Distinct(new RecordsComparer()).ToList();
        }
    }
}
