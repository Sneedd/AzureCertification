using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Example
{
    /// <summary>
    /// 
    /// </summary>
    public class SerializationEx
    {
        #region Binary Serialization Examples

        /// <summary>
        /// 
        /// </summary>
        public void RunBinarySerializationExample()
        {
            DateTime current = DateTime.MinValue;
            PizzaService service = PizzaService.Create();
            using (MemoryStream stream = new MemoryStream(64 * 1024))
            {
                // -----------------------------------------
                // Serialize using the BinaryFormatter
                // - The one rule is that you need the [Serializable] attribute on the class deklaration
                // - The BinaryFormatter can ignore fields when using the [NonSerialized] attribute on the field
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, service);
                Console.WriteLine("[BinaryFormatter] Size of serialized object = {0} Bytes", stream.Length);

                // -----------------------------------------
                // Deserialize using the BinaryFormatter
                stream.Seek(0, SeekOrigin.Begin);
                service = (PizzaService)formatter.Deserialize(stream);

                // -----------------------------------------
                // Implementing a custom serialization using the binary formatter
                stream.SetLength(0);
                formatter.Serialize(stream, new BinaryFormatterExample());
                stream.Seek(0, SeekOrigin.Begin);
                var example = (BinaryFormatterExample)formatter.Deserialize(stream);

                // -----------------------------------------
                // Using the context to provide addtional information or Services
                formatter.Context = new StreamingContext(StreamingContextStates.Remoting, "Hello services");
                formatter.Serialize(stream, new BinaryFormatterExample());
                stream.Seek(0, SeekOrigin.Begin);
                Console.Write("[BinaryFormatter] The additional information with in the context says = ");
                example = (BinaryFormatterExample)formatter.Deserialize(stream);
                Console.WriteLine();

                // -----------------------------------------
                // Using the SerializationBinder to provide types
                // TODO
                
                // formatter.AssemblyFormat
                // formatter.TypeFormat
                // formatter.FilterLevel = TypeFilterLevel.
            }
        }

        /// <summary>
        /// The BinaryFormatterExample class implements the ISerializable interface to show the BinaryFormatter serialization.
        /// <para>This implementation shows the typical implementation when the given class can be used as a base class.</para>
        /// </summary>
        [Serializable]
        public class BinaryFormatterExample : ISerializable
        {
            private int m_id;
            private string m_name;
            private List<int> m_listdata;

            /// <summary>
            /// Constructor, initializes the BinaryFormatterExample object.
            /// </summary>
            public BinaryFormatterExample()
            {
                m_id = 12;
                m_name = "Hello";
                m_listdata = new List<int> { 1, 2, 3, 4 };
            }

            /// <summary>
            /// Deserialization constructor, deserialize the serialization information into this object.
            /// </summary>
            /// <param name="info">Serialization information</param>
            /// <param name="context">Addtional context information</param>
            protected BinaryFormatterExample(SerializationInfo info, StreamingContext context)
            {
                // The default serialization ...
                m_id = info.GetInt32("id");
                
                // ... or alternative when the inner serialization changed.
                foreach (SerializationEntry entry in info)
                {
                    if (entry.Name == "name")
                    {
                        m_name = (string)entry.Value;
                    }
                    else if (entry.Name == "data")
                    {
                        m_listdata = (List<int>)entry.Value;
                    }
                }

                // By the way ... you could use the context ... for example to transport a ServiceProvider
                if (context.Context != null)
                {
                    Console.Write(context.Context.ToString());
                }
            }

            /// <summary>
            /// Serializes this object into the serialization information.
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            {
                this.GetObjectData(info, context);
            }

            /// <summary>
            /// Serializes this object into the serialization information.
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("id", m_id);
                info.AddValue("name", m_name);
                info.AddValue("data", m_listdata);
            }
        }

        #endregion

        #region XmlSerialization Examples

        /// <summary>
        /// 
        /// </summary>
        public void RunXmlSerializationExample()
        {
            PizzaService service = PizzaService.Create();
            using (MemoryStream stream = new MemoryStream(64 * 1024))
            {
                // -----------------------------------------
                // Serialize into XML using the XmlSerializer
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(PizzaService));
                xmlSerializer.Serialize(stream, service);

                // -----------------------------------------
                // Convert the binary encoded XML String into a string variable
                string xmlText = Encoding.UTF8.GetString(stream.ToArray());

                // -----------------------------------------
                // Using the XmlSerializer to create the object from XML
                stream.Seek(0, SeekOrigin.Begin);
                xmlSerializer = new XmlSerializer(typeof(PizzaService));
                service = (PizzaService)xmlSerializer.Deserialize(stream);

                // -----------------------------------------
                // Check if given XML is valid 
                xmlSerializer = new XmlSerializer(typeof(PizzaService));
                using (XmlReader reader = new XmlTextReader(new StringReader(xmlText)))
                {
                    bool check = xmlSerializer.CanDeserialize(reader);
                    Console.WriteLine("[XmlSerialization] Given XML is valid = {0}", check);
                }

                // -----------------------------------------
                // TODO: XmlDocument
                // TODO: XmlReader, XmlWriter
            }
        }

        #endregion

        #region JSON Serialization Examples

        /// <summary>
        /// 
        /// </summary>
        public void RunJsonSerializationExample()
        {
            PizzaService service = PizzaService.Create();
            using (MemoryStream stream = new MemoryStream(64 * 1024))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                // -----------------------------------------
                // Serialize the Object "service" in the TextWriter "writer"
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(writer, service);
                writer.Flush();
                Console.WriteLine("[JsonSerialization] Size of JSON serialized object = {0} Bytes", stream.Length);

                // -----------------------------------------
                // Convert the binary encoded JSON String into a string variable
                string jsonText = Encoding.UTF8.GetString(stream.ToArray());
                Console.WriteLine("[JsonSerialization] Encoded into JSON = {0}...", jsonText.Substring(0, 10));

                // -----------------------------------------
                // Check if JSON is valid
                try
                {
                    JToken token = JToken.Parse(jsonText);
                    Console.WriteLine("[JsonSerialization] The given JSON is valid.");
                }
                catch (Exception)
                {
                    Console.WriteLine("[JsonSerialization] The given JSON is NOT valid.");
                }

                // TODO
            }
        }

        #endregion

        #region DataContract Serialization Examples 

        /// <summary>
        /// 
        /// </summary>
        public void RunDataContractSerializationExample()
        {
        }

        #endregion
    }
}