using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Engine
{
    public static class StringJoinHelper
    {
        public static string JoinWithoutEmptyStrings(string separator, IEnumerable<string?> strings)
        {
            var nonEmptyWords = strings.Where(word => !string.IsNullOrWhiteSpace(word));

            return string.Join(separator, nonEmptyWords);
        }


        public static string JoinWithoutEmptyStrings(string separator, params string?[] strings)
        {
            return JoinWithoutEmptyStrings(separator, strings.ToList());
        }
    }
}
