using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class ConsumeTypes
    {
        #region Conversion Examples

        public void RunConversionExamples()
        {
            // --------------------------------------------------------------------------------------------
            // - Boxing and unboxing https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing
            //   It is the process of converting an type into the object type, which is from a perfomance point of 
            //   view relativly expensive. Also a object need some extra type information stored in memory.
            // 
            // - The var keyword https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/var
            //   The only use for this keyword is to shortcut the writing of a type in a variable declaration.
            //   It cannot be used in method declarations or similar.
            // 

            // --------------------------------------------------------------------------------------------
            // Boxing and Unboxing
            int value = 0;

            // -----------------------------------------
            // To box a value simply make an impicit conversion into this type
            object boxedValue = value;
            Type boxedType = boxedValue.GetType();

            // -----------------------------------------
            // To unbox a value use an explicit conversion 
            value = (int)boxedValue;
            Console.WriteLine("[Boxing] The boxed type is '{0}'.", boxedType.Name);

            // --------------------------------------------------------------------------------------------
            // The var keyword
            string text = "Hello";
            var text2 = "World";  // It is simly shorter
            Console.WriteLine("[VarKeyword] Hey there ... " + text + " " + text2);
        }

        #endregion

        #region Dynamic Examples

        public void RunDynamicExamples()
        {
            // --------------------------------------------------------------------------------------------
            // - The dynamic keyword https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/using-type-dynamic
            // 

            // --------------------------------------------------------------------------------------------
            // Using for different types
            Console.Write("[dynamic] Dynamic variable = ");
            dynamic value = null;
            Console.Write("{0}, ", value != null ? value.ToString() : "(null)");
            value = "I can be everything";
            Console.Write("{0}, ", value != null ? value.ToString() : "(null)");
            value = 123;
            Console.Write("{0}, ", value != null ? value.ToString() : "(null)");
            value = DateTime.Today;
            Console.Write("{0} ", value != null ? value.ToString() : "(null)");
            Console.WriteLine();


            // --------------------------------------------------------------------------------------------
            // Using for complex types and calls to their methods
            dynamic temp = new DynamicExample();
            
            // -----------------------------------------
            // No IntelliSense for Add() though
            Console.WriteLine("[dynamic.MethodCall] Int = {0}, string = {1}, DateTime = {2}",
                temp.Add(3, 7), temp.Add("Foo", "Bar"), temp.Add(new DateTime(2010, 1, 1), TimeSpan.FromDays(30)));

            // -----------------------------------------
            // Lexical checks happen at runtime
            try
            {
                temp.Sub(5, 3);
            }
            catch (RuntimeBinderException ex)
            {
                Console.WriteLine("[dynamic.MissingMethodCall] Exception = {0}", ex.Message);
            }

            // -----------------------------------------
            // Some extensive dynamic example
            Console.WriteLine("[dynamic.MultiMethod] Int = {0}, string = {1}, DateTime = {2}",
                temp.Conversion(123), temp.Conversion("FooBar"), temp.Conversion(new DateTime(2010, 1, 1)));


            // --------------------------------------------------------------------------------------------
            // Performance
            //   Testing the performance of normal, boxed and dynamic assignment and operations.
            //   Another downside of dynamic is the complied result when viewing for example in ILSpy. 
            //   Just try.
            
            // -----------------------------------------
            // Normal add and assignment
            int intValue = 123;
            int intValue2 = 345;
            int intTimes = 100000000;
            DateTime intCurrent = DateTime.UtcNow;
            for (int i = 0; i < intTimes; ++i)
            {
                intValue = intValue2 + intValue;
            }
            TimeSpan intResult = DateTime.UtcNow - intCurrent;

            // -----------------------------------------
            // Boxed add and assignment
            object boxValue = 123;
            object boxValue2 = boxValue;
            int boxTimes = 100000000;
            DateTime boxCurrent = DateTime.UtcNow;
            for (int i = 0; i < boxTimes; ++i)
            {
                boxValue2 = (int)boxValue2 + (int)boxValue;
            }
            TimeSpan boxResult = DateTime.UtcNow - boxCurrent;

            // -----------------------------------------
            // Dynamic add and assignment
            dynamic dynamicValue = 123;
            dynamic dynamicValue2 = boxValue;
            int dynamicTimes = 100000000;
            DateTime dynamicCurrent = DateTime.UtcNow;
            for (int i = 0; i < dynamicTimes; ++i)
            {
                dynamicValue2 = dynamicValue2 + dynamicValue;
            }
            TimeSpan dynamicResult = DateTime.UtcNow - dynamicCurrent;

            // -----------------------------------------
            // Display results
            Console.WriteLine("[dynamic.Performance] Normal = {0:0.000}, Boxing = {1:0.000}, Dynamic = {2:0.000}",
                intResult.TotalSeconds, boxResult.TotalSeconds, dynamicResult.TotalSeconds);
        }

        public class DynamicExample
        {
            public dynamic Add(dynamic a, dynamic b)
            {
                return (a + b);
            }

            public string Conversion(dynamic value)
            {
                return (this.ConversionIntern(value));
            }

            protected string ConversionIntern(int value)
            {
                return (string.Format("Int:{0}", value));
            }
            protected string ConversionIntern(string value)
            {
                return (string.Format("String:{0}", value));
            }
            protected string ConversionIntern(DateTime value)
            {
                return (string.Format("DateTime:{0}", value));
            }
        }

        #endregion

        #region Expando Examples

        public void RunExpandoExamples()
        {
            // --------------------------------------------------------------------------------------------
            // - ExpandoObject class https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject
            //   The ExpandoObject can only be used together with the dynamic keyword, otherwise it returns an compile error.

            // -----------------------------------------
            // Creating a hierarchy of expando objects
            dynamic expando = new ExpandoObject();
            expando.Foo = "What is Foo?";
            expando.IsOppositeOf = new ExpandoObject();
            expando.IsOppositeOf.Bar = "Foo is the opposite of Bar!";

            // -----------------------------------------
            // And access it 
            Console.WriteLine("[Expando] {0} {1}", expando.Foo, expando.IsOppositeOf.Bar);

            // -----------------------------------------
            // Or loop through it 
            Console.Write("[Expando] TopLevel = ");
            foreach (KeyValuePair<string, object> pair in expando)
            {
                Console.Write(pair.Key);
                Console.Write(" ");
            }
            Console.WriteLine();            
        }

        #endregion

        #region DynamicObject Examples

        public void RunDynamicObjectExamples()
        {
            // --------------------------------------------------------------------------------------------
            // - DynamicObject class https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject

            // -----------------------------------------
            // Here an example for own dynamic class
            Console.Write("[DynamicObject] Invokations = ");
            dynamic namedList = new DynamicNamedList();
            namedList.Foo = "Foo";
            namedList.Bar = "Bar";
            namedList.FooBar = namedList.Foo + namedList.Bar;
            Console.WriteLine();
        }

        public class DynamicNamedList : DynamicObject
        {
            List<KeyValuePair<string, object>> m_namedlist = new List<KeyValuePair<string, object>>();

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                Console.Write("Get({0}) ", binder.Name);
                int index = m_namedlist.FindIndex(a => string.Compare(a.Key, binder.Name, binder.IgnoreCase) == 0);
                result = index < 0 ? null : m_namedlist[index].Value;
                return (index >= 0);
            }

            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                Console.Write("Set({0}) ", binder.Name);
                int index = m_namedlist.FindIndex(a => string.Compare(a.Key, binder.Name, binder.IgnoreCase) == 0);
                if (index < 0)
                {
                    m_namedlist.Add(new KeyValuePair<string, object>(binder.Name, value));
                }
                else
                {
                    m_namedlist[index] = new KeyValuePair<string, object>(binder.Name, value);
                }
                return (true);
            }
        }

        #endregion
    }
}
