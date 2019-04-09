using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
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

        public enum ObjectState
        {
            Initializing = 0,
            Initialized = 1,
            Disposing = 2,
            Disposed = 3
        }

        public class LockingExample
        {
            public int Counter { get; private set; }

            public LockingExample()
            {
                this.Counter = 0;
            }

            public int Next()
            {
                this.Counter += 1;
                Thread.Sleep(50);
                return (this.Counter);
            }
        }

        public class LockingSynchonizedExample
        {
            public int Counter { get; private set; }

            public LockingSynchonizedExample()
            {
                this.Counter = 0;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            public int Next()
            {
                this.Counter += 1;
                Thread.Sleep(50);
                return (this.Counter);
            }
        }

        public void RunLockingExamples()
        {
            // --------------------------------------------------------------------------------------------
            // Without Locking
            //   Here an example of an always wrong synchronization we actually want here 1,2,3,4,5
            var lockingExample = new LockingExample();
            var taskList = new List<Task>();
            Console.Write("[Locking.WithoutLocking] Unsynchronized returns = ");
            for (int i = 0; i < 6; ++i)
            {
                Task task = Task.Run(() => Console.Write(lockingExample.Next()));
                taskList.Add(task);
            }
            Task.WaitAll(taskList.ToArray());
            Console.WriteLine();

            // --------------------------------------------------------------------------------------------
            // lock
            //   While you could use the reference of the current class for example 'this', it is not 
            //   recommended, because it will be easier to create deadlocks. Therefore create an object
            //   which reference will be used for locking.
            lockingExample = new LockingExample();
            taskList = new List<Task>();
            object lockKeyword = new object();
            Console.Write("[Lock.Keyword] Synchronized returns = ");
            for (int i = 0; i < 6; ++i)
            {
                Task task = Task.Run(() =>
                {
                    lock (lockKeyword)
                    {
                        Console.Write(lockingExample.Next());
                    }
                });
                taskList.Add(task);
            }
            Task.WaitAll(taskList.ToArray());
            Console.WriteLine();


            // --------------------------------------------------------------------------------------------
            // Interlocked.CompareExchange()
            //   Whilst wierd syntax and description ...
            //   The first argument is the reference is the stored state object
            //   The second argument ist the new state and will be changed only if the last argument matches the current state.
            //   The third argument ist the actual state used for comparison.
            int state = (int)ObjectState.Initializing;
            Console.Write("[Interlocked.CompareExchange] Object is '{0}' ", (ObjectState)state);
            Interlocked.CompareExchange(ref state, (int)ObjectState.Initialized, (int)ObjectState.Initializing);
            Console.Write("then '{0}' ... ", (ObjectState)state);
            Interlocked.CompareExchange(ref state, (int)ObjectState.Disposing, (int)ObjectState.Initialized);
            Console.Write("and later '{0}' ", (ObjectState)state);
            Interlocked.CompareExchange(ref state, (int)ObjectState.Disposed, (int)ObjectState.Disposing);
            Console.WriteLine("and '{0}'. ", (ObjectState)state);

            // --------------------------------------------------------------------------------------------
            // Speed Comparison
            //   This just compares the plain speed of the previous locking techniques.
            //   While this does not take in account the algorithm itself or when waiting ... it gives a little hint of what technique to use in a different situations.
            //   For example the lock Statement is a little bit less speedy than Interlocked when think of a simple state variable.
            int times = 50000000;
            DateTime current = DateTime.UtcNow;
            current = DateTime.UtcNow;
            object _lock = new object();
            for (int i = 0; i < times; ++i)
            {
                lock (_lock)
                { }
            }
            Console.WriteLine("[Lock] Entered and exited '{0:n0}' times in '{1:0.000}' seconds.", times, ((DateTime.UtcNow - current).TotalSeconds));
            current = DateTime.UtcNow;
            for (int i = 0; i < times; ++i)
            {
                state = (int)ObjectState.Initializing;
                Interlocked.CompareExchange(ref state, (int)ObjectState.Initialized, (int)ObjectState.Initializing);
            }
            Console.WriteLine("[Interlocked.CompareExchange] Compared and exchanged '{0:n0}' times in '{1:0.000}' seconds.", times, ((DateTime.UtcNow - current).TotalSeconds));

            // --------------------------------------------------------------------------------------------
            // MethodImpl Synchronized
            //   While in this example a instance is used for this locking technik.
            var lockingSyncExample = new LockingSynchonizedExample();
            taskList = new List<Task>();
            Console.Write("[MethodImpl.Synchronized] Synchronized returns = ");
            for (int i = 0; i < 6; ++i)
            {
                Task task = Task.Run(() => Console.Write(lockingSyncExample.Next()));
                taskList.Add(task);
            }
            Task.WaitAll(taskList.ToArray(), 500);
            Console.WriteLine();
        }

        #endregion

        #region Cancel Tasks Example

        public void RunCancelTasksExamples()
        {
            // --------------------------------------------------------------------------------------------
            // CancelationToken 
            //   The CanceltationTokenSource can be used with an timer.
            DateTime current = DateTime.UtcNow;
            CancellationTokenSource source = new CancellationTokenSource();
            var taskList = new List<Task>(20000);
            for (int i = 0; i < 20000; ++i)
            {
                Action action = () =>
                {
                    CancellationToken token = source.Token;
                    while (!token.IsCancellationRequested)
                    {
                        Thread.Sleep(50);
                    }
                };
                taskList.Add(Task.Run(action, source.Token));
            }
            Thread.Sleep(500);
            source.Cancel();
            try
            {
                Task.WaitAll(taskList.ToArray());
            }
            catch (AggregateException) { }
            Console.WriteLine("[CancelationToken.Simple] All tasks are canceled within '{0:0.000}' seconds.", (DateTime.UtcNow - current).TotalSeconds);


            // --------------------------------------------------------------------------------------------
            // CancelationToken with timer
            //   The CanceltationTokenSource can be used with an timer.
            current = DateTime.UtcNow;
            source = new CancellationTokenSource(500);
            taskList = new List<Task>(20000);
            for (int i = 0; i < 20000; ++i)
            {
                Action action = () =>
                {
                    CancellationToken token = source.Token;
                    while (!token.IsCancellationRequested)
                    {
                        Thread.Sleep(50);
                    }
                };
                taskList.Add(Task.Run(action, source.Token));
            }
            try
            {
                Task.WaitAll(taskList.ToArray());
            }
            catch (AggregateException) { }
            Console.WriteLine("[CancelationToken.Timed] All tasks are canceled within '{0:0.000}' seconds.", (DateTime.UtcNow - current).TotalSeconds);
        }

        #endregion

        internal void RunRaceConditionsExamples()
        {
        }
    }
}