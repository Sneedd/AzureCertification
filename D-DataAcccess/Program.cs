using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // ---------------------------------------------------------------------
            // Zertifizierung 70-483 - Programieren in C#
            // Link: https://www.microsoft.com/en-us/learning/exam-70-483.aspx
            // 

            // Perform I/ O operations
            // - FileSystem Methods (System.IO)
            (new IOEx()).RunFileSystemExamples();
            // - Read and write streams (synchronus and asynchronous)
            (new IOEx()).RunStreamExamples();
            // - Network Streams (System.Net)
            (new IOEx()).RunNetworkStreamExamples();

            // Consume data
            // - Using ADO.NET
            (new ConsumeData()).RunAdoNetExamples();
            // - Retrieve data by WebServices
            (new ConsumeData()).RunUsingWebServicesExamples();
            // - Consume JSON and XML data from WebService
            (new ConsumeData()).RunConsumeJsonXmlDataExamples();

            // Query and manipulate data and objects by using LINQ
            // Select data by using anonymous types
            (new LinqExamples()).RunLinqSelectExamples();
            // Using query comprehension syntax
            (new LinqExamples()).RunLinqClauseExamples();
            // - create methodbased LINQ queries; 
            // - Query data by using operators, including projection, join, group, take, skip, aggregate
            // - query data by using query comprehension syntax; 
            // - force execution of a query; 
            // - read, filter, create, and modify data structures by using LINQ to XML

            // Serialize and deserialize data
            // - Serialize and deserialize data by using binary serialization, custom serialization, 
            (new SerializationEx()).RunBinarySerializationExample();
            // - XML Serializer, 
            (new SerializationEx()).RunXmlSerializationExample();
            // - JSON Serializer
            (new SerializationEx()).RunJsonSerializationExample();
            // - Data Contract Serializer
            (new SerializationEx()).RunDataContractSerializationExample();

            // Store data in and retrieve data from collections
            // - Store and retrieve data by using dictionaries, arrays, lists, sets, and queues; 
            // - choose a collection type; 
            // - initialize a collection; 
            // - add and remove items from a collection; 
            // - use typed vs.non-typed collections; 
            // - implement custom collections; 
            // - implement collection interfaces

            Console.WriteLine("Press any key ...");
            Console.ReadKey();
        }
    }
}
