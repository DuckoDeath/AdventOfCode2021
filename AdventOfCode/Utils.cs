using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Utils
    {
        public static int GetIntFromBinary(char[] parts)
        {
            var multiplier = 1;
            var result = 0;
            for (int i = parts.Length - 1; i >= 0; i--)
            {
                var val = int.Parse(parts[i].ToString());
                result += (multiplier * val);
                multiplier *= 2;
            }
            return result;

        }
    }
}
