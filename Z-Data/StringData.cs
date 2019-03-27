using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public static class StringData
    {
        public static string GetBible()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Example.Resources.bible.txt"))
            using (StreamReader reader = new StreamReader(stream))
            {
                return (reader.ReadToEnd());
            }
        }
    }
}
