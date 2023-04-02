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
            // Create and use types
            //
            // Exam 70-483 - Programming in C#
            // https://www.microsoft.com/en-us/learning/exam-70-483.aspx
            // 

            // ---------------------------------------------------------------------
            // Create types
            // TODO

            //// ---------------------------------------------------------------------
            //// Consume types
            //// - Boxing, unboxing and var Keyword
            //(new ConsumeTypes()).RunConversionExamples();
            //// - Dynamic
            //(new ConsumeTypes()).RunDynamicExamples();
            //(new ConsumeTypes()).RunExpandoExamples();
            //(new ConsumeTypes()).RunDynamicObjectExamples();


            //(new ImplementingInterfaces()).RunIDisposableExamples();
            (new ImplementingInterfaces()).RunCustomFormatterExamples();
            

            Console.WriteLine("Press any key ...");
            Console.ReadKey();
        }
    }
}
