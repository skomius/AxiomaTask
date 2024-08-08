using AxiomaTask.Models;
using CsvHelper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiomaTask
{
    internal class FileImporter
    {
        static internal void ImportFile(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                var d = csv.HeaderRecord;
                while (csv.Read())
                {
                    var record = csv.GetRecord<Record>();
                    LogsCollection.LogsRecords.Add(record);
                }
            }

            LogsCollection.LogsRecords = LogsCollection.LogsRecords.Distinct(new RecordsComparer()).ToList();
        }
    }
}
