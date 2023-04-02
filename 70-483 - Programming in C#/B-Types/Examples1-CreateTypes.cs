using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class CreateTypes
    {

    }


    public static class StringExtensions
    {
        public static string Cut(this string value, int maxSize)
        {
            if (value.Length <= maxSize)
            {
                return (value);
            }
            value = value.Substring(0, maxSize - 3);
            return (value + "...");
        }
    }

}
