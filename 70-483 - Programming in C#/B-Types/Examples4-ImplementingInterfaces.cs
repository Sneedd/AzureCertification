using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example
{
    public class ImplementingInterfaces
    {
        #region IComparable Examples




        #endregion

        #region IDisposable Examples

        public void RunIDisposableExamples()
        {
            Action a1 = () =>
            {
                Console.Write("[Finalizer.IDisposable.Dispose] ");
                for (int i = 0; i < 1; ++i)
                {
                    var instance = new ClassWithFinalizer();
                    instance.Dispose();
                    instance = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Console.WriteLine();
            };
            a1();

            Action a2 = () =>
            {
                Console.Write("[Finalizer.IDisposable.NoDispose] ");
                for (int i = 0; i < 1; ++i)
                {
                    var instance = new ClassWithFinalizer();
                    instance = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Console.WriteLine();
            };
            a2();

            Action a3 = () =>
            {
                Console.Write("[NoFinalizer.IDisposable.Dispose] ");
                for (int i = 0; i < 1; ++i)
                {
                    var instance = new ClassWithoutFinalizer();
                    instance.Dispose();
                    instance = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Console.WriteLine();
            };
            a3();

            Action a4 = () =>
            {

                Console.Write("[NoFinalizer.IDisposable.NoDispose] ");
                for (int i = 0; i < 1; ++i)
                {
                    var instance = new ClassWithoutFinalizer();
                    instance = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Console.WriteLine();
            };
            a4();
        }

        public class ClassWithFinalizer : IDisposable
        {
            bool disposed = false;

            public void Dispose()
            {
                Console.Write("Dispose ");
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposed)
                {
                    return;
                }

                if (disposing)
                {
                    // Free any other managed objects here.
                    Console.Write("Dispose[Managed] ");
                }

                // Free any unmanaged objects here.
                Console.Write("Dispose[Unmanaged] ");

                disposed = true;
            }

            ~ClassWithFinalizer()
            {
                Console.Write("Finalizer ");
                Dispose(false);
            }
        }

        public class ClassWithoutFinalizer : IDisposable
        {
            bool disposed = false;

            public void Dispose()
            {
                Console.Write("Dispose ");
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposed)
                {
                    return;
                }
                if (disposing)
                {
                    // Free any other managed objects here.
                    Console.Write("Dispose[Managed] ");
                }

                // Free any unmanaged objects here.
                Console.Write("Dispose[Unmanaged] ");
                disposed = true;
            }
        }

        #endregion
        
        #region ICustomFormatter Examples

        public void RunCustomFormatterExamples()
        {
            MacAddress2 address = new MacAddress2 { Address = new byte[] { 0xAA, 0xBB, 0xCC, 0x11, 0x22, 0x33 } };
            Console.WriteLine("[ICustomFormatter] {0}", string.Format(new MultiFormatter(), "Result = {0}", address));

            IpAddress2 address2 = new IpAddress2 { Address = new byte[] { 127, 0, 0, 1 } };
            Console.WriteLine("[ICustomFormatter] {0}", string.Format(new MultiFormatter(), "Result = {0}", address2));

            Console.WriteLine("[ICustomFormatter] {0}", string.Format(new MultiFormatter(), "Result = {0}", (int)123456));
        }

        public struct MacAddress2
        {
            public byte[] Address;
        }

        public struct IpAddress2
        {
            public byte[] Address;
        }

        public class MultiFormatter : ICustomFormatter, IFormatProvider
        {
            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                if (arg is MacAddress2 address)
                {                    
                    return ("MacAddress:" + string.Join("-", address.Address.Select(a => a.ToString("X"))));
                }
                else if (arg is IpAddress2 address2)
                {
                    return ("IpAddress:" + string.Join(".", address2.Address.Select(a => a.ToString())));
                }
                else if (arg is int value)
                {
                    return ("int:" + value.ToString());
                }
                else
                {
                    return (string.Empty);
                }
            }

            public object GetFormat(Type formatType)
            {
                if (formatType == typeof(ICustomFormatter))
                {
                    return (this);
                }
                return (null);
            }
        }

        #endregion
    }
}
