﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AxiomaTask
{
    internal class ParseResult
    {
        internal Func<string, bool> Expr { get; set; }
        internal string Property { get; set; }
    }
}
