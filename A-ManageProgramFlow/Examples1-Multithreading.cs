using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Collections.Concurrent;

namespace Example
{
    public class Multithreading
    {
        internal void RunTaskParallelLibraryExamples()
        {
            // --------------------------------------------------------------------------------------------
            // Um Dataflow Bibliothek nutzen zu können muss sie über NuGet erst einmal hinzugefügt werden
            //  

            // --------------------------------------------------------------------------------------------
            // BufferBlock kann als asynchroner Puffer für Nachrichten genutzt werden
            Console.Write("[Tpl.Dataflow.BufferBlock] BufferBlock returns = ");
            var bufferBlock = new BufferBlock<int>();
            Parallel.Invoke(
                () => Parallel.For(0, 20, new ParallelOptions { MaxDegreeOfParallelism = 2 }, a => bufferBlock.Post(a)),
                () => Parallel.For(0, 20, _ => Console.Write("{0}, ", bufferBlock.Receive()))
            );
            Console.WriteLine();




        }

        internal void RunParallelExamples()
        {
            Stopwatch watch = new Stopwatch();

            // --------------------------------------------------------------------------------------------
            // Mit der Klasse Parallel können relativ einfach parallele Aufgaben erzeugt und abgearbeitet werden
            // 

            // --------------------------------------------------------------------------------------------
            // Gibt 0 bis 9 in beliebiger Reihenfolge aus, da jeder Thread 
            //   zu einem anderen Zeitpunkt ausgeführt werden könnte.
            Console.Write("[Parallel.For] Results = ");
            Parallel.For(0, 10, a => Console.Write("{0}, ", a));
            Console.WriteLine();



            // --------------------------------------------------------------------------------------------
            //Parallel.For(0, 50, a => a).



            // --------------------------------------------------------------------------------------------
            // Parallel.ForEach
            //   With Parallel.ForEach() an IEnumerable can be used to create tasks easily.
            watch.Restart();
            string text = StringData.CreateLongString();
            Console.Write("[Parallel.ForEach.Simple] Results = ");
            List<string> searchWords = new List<string> {
                "Gott", "Mann", "Weib"
            };
            Parallel.ForEach(searchWords, a => Console.Write("{0}({1}) ", a, text
                .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Count(b => string.Compare(a, b, true) == 0)));
            Console.WriteLine("in {0:0.000}s", watch.Elapsed.TotalSeconds);

            // --------------------------------------------------------------------------------------------
            // Parallel.ForEach Options
            //   Additionally one can use the ParallelOptions to setup some stuff, here the max amount of Tasks used.
            //   Others are using a different TaskFactory oder including a CancelationToken.
            watch.Restart();
            Console.Write("[Parallel.ForEach.Complex] Results = ");
            Parallel.ForEach(
                searchWords,
                new ParallelOptions { MaxDegreeOfParallelism = 2, }, // Default for MaxDegreeOfParallelism is -1
                (w, s) =>
                {
                    int count = text
                        .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                        .Count(b => string.Compare(w, b, true) == 0);
                    Console.Write("{0}({1}) ", w, count);
                });
            Console.WriteLine("in {0:0.000}s", watch.Elapsed.TotalSeconds);


            // --------------------------------------------------------------------------------------------
            // Parallel.ForEach Break
            //   With Break the Parallel exceution can be stopped. If break was called the next task will not be started.
            watch.Restart();
            searchWords = new List<string> {
                "Gott", "Mann", "Weib", "Mensch", "Teufel", // "Hass", "Gnade", "Brot", "Wein", "Hund", "Tot"
            };
            Console.Write("[Parallel.ForEach.Break] Break results ");
            ParallelLoopResult result = Parallel.ForEach(
            searchWords,
                new ParallelOptions { MaxDegreeOfParallelism = 2, },
                (w, s) =>
                {
                    int count = text
                        .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                        .Count(b => string.Compare(w, b, true) == 0);
                    if (count < 20)
                    {
                        s.Break();
                    }
                });
            Console.Write("in {0:0.000}s ", watch.Elapsed.TotalSeconds);
            Console.WriteLine("while LowestBreakIteration = {0}, Completed = {1}", result.LowestBreakIteration, result.IsCompleted);
        }

        internal void RunPLINQExamples()
        {
            // TODO

            // --------------------------------------------------------------------------------------------
            // Speed Comparison LINQ vs PLINQ
            string text = StringData.CreateLongString();
            List<string> searchWords = new List<string> {
                "Gott", "Mann", "Weib", "Mensch", "Teufel", "Hass", "Gnade", "und", "Brot", "Wein", "oder", "Hund", "Apfel"
            };
            DateTime current = DateTime.UtcNow;
            var results = searchWords.Select(w => new
            {
                Word = w,
                Count = text.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Count(a => a == w)
            }).ToArray();
            Console.Write("[LINQvsPLINQ] LINQ needs {0:0.000}s while ", (DateTime.UtcNow-current).TotalSeconds);
            current = DateTime.UtcNow;
            results = searchWords.AsParallel().Select(w => new
            {
                Word = w,
                Count = text.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Count(a => a == w)
            }).ToArray();
            Console.WriteLine("PLINQ needs {0:0.000}s", (DateTime.UtcNow - current).TotalSeconds);
        }

        internal void RunTaskExamples()
        {
        }

        internal void RunThreadPoolExamples()
        {
        }

        internal void RunUnblockUIExamples()
        {
        }

        internal void RunWaitExamples()
        {
            // --------------------------------------------------------------------------------------------
            // - Thread.Sleep method https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread.sleep
            //   Waits the given time and gives up the remainder of its time slice.
            //   Note, that the waiting execution can immediately continue, when there are no other threads.
            // 
            // - Thread.Yield method https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread.yield
            //   Gives up the remainder of the current threads time splice.
            //   Note, that the execution can immediately continue, when there are no other threads.
            //
            // - Thread.SpinWait method https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread.spinwait
            //   ????
            // 
        }

        internal void RunKeywordsAsyncAwaitExamples()
        {
        }

        #region ConcurrentCollections Examples

        /// <summary>
        /// 
        /// </summary>
        public void RunConcurrentCollectionsExamples()
        {
            // --------------------------------------------------------------------------------------------
            // BlockingCollection<T> Example
            //  The Blocking Collection has an additional signal when the collection completed
            Console.Write("[ConncurrentCollections] BlockingCollection ");
            BlockingCollection<int> blockingCollection = new BlockingCollection<int>();
            Task producer = Task.Run(() => 
            {
                for (int i = 1; i < 5; ++i)
                {
                    blockingCollection.Add(i);
                }
                Console.Write("is about to complete = ");
                blockingCollection.CompleteAdding();
            });
            Task consumer = Task.Run(() => 
            {
                while (!blockingCollection.IsCompleted)
                {
                    Console.Write(blockingCollection.Take());
                }
            });
            Task.WaitAll(producer, consumer);
            Console.WriteLine();

            // --------------------------------------------------------------------------------------------
            // ConcurrentDictionary<TKey, TValue>
            ConcurrentDictionary<string, string> dictionary = new ConcurrentDictionary<string, string>();
            producer = Task.Run(() => 
            {
                //dictionary.A
            });
            consumer = Task.Run(() => { });

            // --------------------------------------------------------------------------------------------
            // ConcurrentQueue<T>
            producer = Task.Run(() => { });
            consumer = Task.Run(() => { });

            // --------------------------------------------------------------------------------------------
            // ConcurrentStack<T>
            producer = Task.Run(() => { });
            consumer = Task.Run(() => { });


            // --------------------------------------------------------------------------------------------
            // ConcurrentBag<T> 
            producer = Task.Run(() => { });
            consumer = Task.Run(() => { });

            // TODO
            //IProducerConsumerCollection<T>


        }

        #endregion
    }
}