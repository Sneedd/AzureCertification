using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Example
{
    public class Locking
    {
        public Locking()
        {
        }

        #region SynchronizeResources Examples

        public void RunSynchronizeResourcesExamples()
        {
        }

        #endregion

        #region Locking Examples

        public void RunLockingExamples()
        {
            // -----------------------------------------
            // Synchronized
            //   While in this example a instance is used for this locking technik.
            var lockingExample = new LockingExample();
            var taskList = new List<Task>();
            Console.Write("[Locking] Synchronized returns = ");
            for (int i = 0; i < 10; ++i)
            {
                Task task = Task.Run(() =>
                {
                    Console.Write(lockingExample.Next());
                });
                taskList.Add(task);
            }
            Task.WaitAll(taskList.ToArray(), 500);
            Console.WriteLine();
        }

        public class LockingExample
        {
            public int Counter { get; set; }

            [MethodImpl(MethodImplOptions.Synchronized)]
            public int Next()
            {
                return (this.Counter++);
            }
        }

        #endregion

        #region Cancel Tasks Example

        public void RunCancelTasksExamples()
        {
        }

        #endregion

        internal void RunRaceConditionsExamples()
        {
        }
    }
}