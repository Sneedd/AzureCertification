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
        /// <summary>
        /// Creates and returns a medium string
        /// </summary>
        /// <returns></returns>
        public static string CreateMediumString()
        {
            return ("pri no consul expetenda ea sed cetero alterum omittantur corpora postulant partiendo eu est cetero audiam ius ad usu te quodsi scaevola at deleniti sententiae sed indoctum contentiones ex sed laoreet meliore et eum eu facer patrioque aliquando per putent recteque sea ad te quis mediocrem expetendis quo eam ut illud etiam eu vix veri volumus voluptatum vis in mandamus maluisset mediocritatem saepe audire oporteat sit te quem nobis democritum eu ius te quas mutat per illum laudem accusata ea eum quo labitur blandit ad ea eos accusam pertinax cu has dolorum intellegat pro et purto dicit laoreet inani iusto periculis ei eos at persius accusamus similique has quas vidisse vis no nam illud aperiam interpretaris ei ei cum brute tacimates ei per postea eligendi fabellas veniam convenire dignissim vix id mei eu posse abhorreant sed in altera maiestatis cu qui alii essent eos ea iuvaret lucilius patrioque et ius alii mnesarchum aperiri probatus vim at");
        }

        /// <summary>
        /// Creates and returns a long string
        /// </summary>
        /// <returns></returns>
        public static string CreateLongString()
        {
            using (MemoryStream stream = StringData.CreateMemoryStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return (reader.ReadToEnd());
            }
        }

        /// <summary>
        /// Creates and returns a byte array
        /// </summary>
        /// <returns></returns>
        public static byte[] CreateByteArray()
        {
            using (MemoryStream stream = StringData.CreateMemoryStream())
            {
                return (stream.ToArray());
            }
        }

        /// <summary>
        /// Creates and returns a MemoryStream
        /// </summary>
        /// <returns></returns>
        public static MemoryStream CreateMemoryStream()
        {
            MemoryStream stream = new MemoryStream(64 * 1024);
            using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Example.Resources.bible.txt"))
            {
                int count = 0;
                byte[] buffer = new byte[4 * 1024];
                while ((count = resourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, count);
                }
            }
            return (stream);
        }

        /// <summary>
        /// Creates and returns a filename to a temporary file.
        /// </summary>
        /// <returns></returns>
        public static string CreateTemporaryFile()
        {
            string pathToFile = Path.GetTempFileName();
            File.WriteAllBytes(pathToFile, StringData.CreateByteArray());
            return (pathToFile);
        }
    }
}
