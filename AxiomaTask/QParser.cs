﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AxiomaTask.ValueObjects;

namespace AxiomaTask
{
    internal static class QParser
    {
        static internal ParseResult QueryParser(string query)
        {
            var parsedField = query.Split('=');

            if (parsedField.Length != 2)
            {
                throw new InvalidOperationException("Query parsing failed");
            }

            var field = new Field
            {
                Property = parsedField[0],
                Op = "=",
                Value = parsedField[1]
            };

            bool boolOut;

            if (bool.TryParse(field.Value, out boolOut))
            {
                return new ParseResult { Value = boolOut, Property = field.Property };
            }
            else if (field.Value.StartsWith('\'') && field.Value.EndsWith('\''))
            {
                return new ParseResult { Value = field.Value, Expr = ValueParser(field.Value), Property = field.Property };
            }
            else
            {
                throw new InvalidOperationException("Query parsing failed");
            }
        }

        static private Func<string, bool> ValueParser(string value)
        {
            var valueNoQuotes = value.Trim('\'');
            var valueNoAsterisk = valueNoQuotes.Trim('*');

            Func<string, bool> expr = (valueNoQuotes.StartsWith('*'), valueNoQuotes.EndsWith('*')) switch
            {
                (false, false) => x => x == valueNoQuotes,
                (true, false) => x => x.EndsWith(valueNoAsterisk),
                (false, true) => x => x.StartsWith(valueNoAsterisk),
                (true, true) => x => x.Contains(valueNoAsterisk)
            };

            return expr;
        }
    }
}
