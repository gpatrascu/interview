using System;
using System.Collections.Generic;
using System.Linq;

namespace DataMunging
{
    public static class TableParser
    {
        public static TR GetValue<TO, TR>(IEnumerable<string> lines,
            Func<IList<string>, TO> orderByFunction,
            Func<IList<string>, TR> selectFunction)
        {
            return lines
                .Select(line => line.Trim())
                .Where(line => line.Length > 0 && char.IsDigit(line[0]))
                .Select(Split)
                .OrderBy(orderByFunction)
                .Select(selectFunction)
                .First();
        }

        private static IList<string> Split(string line)
        {
            return line.Split(new[] {' ', '*'}, StringSplitOptions.RemoveEmptyEntries);
        }

        public static TR GetValue<TO, TR>(string allText,
            Func<IList<string>, TO> orderByFunction,
            Func<IList<string>, TR> selectFunction)
        {
            return GetValue(allText.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .ToList(), orderByFunction, selectFunction);
        }
    }
}