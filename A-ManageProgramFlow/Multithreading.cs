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
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Dataflow");
            Console.WriteLine();

            // --------------------------------------------------------------------------------------------
            // BufferBlock kann als asynchroner Puffer für Nachrichten genutzt werden
            var bufferBlock = new BufferBlock<int>();
            Parallel.Invoke(
                () => Parallel.For(0, 20, new ParallelOptions { MaxDegreeOfParallelism = 2 }, a => bufferBlock.Post(a)),
                () => Parallel.For(0, 20, _ => Console.Write("{0}, ", bufferBlock.Receive()))
            );
            Console.WriteLine();
            Console.WriteLine();
        }

        internal void RunParallelExamples()
        {
            Stopwatch watch = new Stopwatch();

            // --------------------------------------------------------------------------------------------
            // Mit der Klasse Parallel können relativ einfach parallele Aufgaben erzeugt und abgearbeitet werden
            // 
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("ParallelFor");
            Console.WriteLine();


            // --------------------------------------------------------------------------------------------
            // Gibt 0 bis 9 in beliebiger Reihenfolge aus, da jeder Thread 
            //   zu einem anderen Zeitpunkt ausgeführt werden könnte.
            Parallel.For(0, 10, a => Console.Write("{0}, ", a));
            Console.WriteLine();
            Console.WriteLine();



            // --------------------------------------------------------------------------------------------
            //Parallel.For(0, 50, a => a).



            // --------------------------------------------------------------------------------------------
            // Sucht in dem Bibel Text nach der Anzahl der aufgeführten Wörter
            watch.Restart();
            string bible = StringData.GetBible();
            List<string> searchWords = new List<string> {
                "Himmel", "Hölle", "Gott", "Gold", "Teufel", "Mann", "Weib"
            };
            Parallel.ForEach(searchWords, a => Console.WriteLine("{0} Count = {1}", a, bible
                .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Count(b => string.Compare(a, b, true) == 0)));
            Console.WriteLine("Elapsed time = {0:0.000}s", watch.Elapsed.TotalSeconds);
            Console.WriteLine();
            Console.WriteLine();

            // --------------------------------------------------------------------------------------------
            // Sucht in dem Bibel Text nach der Anzahl der aufgeführten Wörter mit maximal 2 Threads
            watch.Restart();
            Parallel.ForEach(
                searchWords,
                new ParallelOptions { MaxDegreeOfParallelism = 2, },
                (w, s) =>
                {
                    int count = bible
                        .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                        .Count(b => string.Compare(w, b, true) == 0);
                    Console.WriteLine("{0} Count = {1}", w, count);
                });
            Console.WriteLine("Elapsed time = {0:0.000}s", watch.Elapsed.TotalSeconds);
            Console.WriteLine();
            Console.WriteLine();


            // --------------------------------------------------------------------------------------------
            // Sucht in dem Bibel Text nach der Anzahl der aufgeführten Wörter mit maximal 2 Threads
            watch.Restart();
            ParallelLoopResult result = Parallel.ForEach(
                searchWords,
                new ParallelOptions { MaxDegreeOfParallelism = 2, },
                (w, s) =>
                {
                    int count = bible
                        .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                        .Count(b => string.Compare(w, b, true) == 0);
                    if (count < 200)
                    {
                        s.Break();
                    }
                    Console.WriteLine("{0} Count = {1}", w, count);
                });
            Console.WriteLine("LowestBreakIteration = {0}, Completed = {1}", result.LowestBreakIteration, result.IsCompleted);
            Console.WriteLine("Elapsed time = {0:0.000}s", watch.Elapsed.TotalSeconds);
            Console.WriteLine();
            Console.WriteLine();

        }

        internal void RunPLINQExamples()
        {
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