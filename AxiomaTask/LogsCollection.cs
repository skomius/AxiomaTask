﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiomaTask
{
    static internal class LogsCollection
    {
        internal static BlockingCollection<Record> LogsRecords = new BlockingCollection<Record>();
    }
}
