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

            // Implement multithreading and asynchronous processing
            // - Use the Task Parallel library            
            (new Multithreading()).RunTaskParallelLibraryExamples();
            // - Parallel Class
            (new Multithreading()).RunParallelExamples();
            // - PLINQ 
            (new Multithreading()).RunPLINQExamples();
            // - Tasks
            (new Multithreading()).RunTaskExamples();
            // - ThreadPool
            (new Multithreading()).RunThreadPoolExamples();
            // - Unblock the UI
            (new Multithreading()).RunUnblockUIExamples();
            // - Keywords async and await 
            (new Multithreading()).RunKeywordsAsyncAwaitExamples();
            // - Concurrent collections
            (new Multithreading()).RunConcurrentCollectionsExamples();

            // Manage multithreading
            // - Synchronize resources
            (new Locking()).RunSynchronizeResourcesExamples();
            // - Locking
            (new Locking()).RunLockingExamples();
            // - Cancel a long-running task
            (new Locking()).RunCancelTasksExamples();
            // - Implement thread-safe methods to handle race conditions
            (new Locking()).RunRaceConditionsExamples();

            // Implement program flow
            // - Iterate across collection and array items
            (new ProgramFlow()).RunIterationExamples();
            // - Decisions with switch and if statements
            (new ProgramFlow()).RunDecisionsExamples();
            // - evaluate expressions
            (new ProgramFlow()).RunEvaluateExpressionsExamples();
            // - Event handling (create, subscribe, unsubscribe, ...)
            (new ProgramFlow()).RunEventHandlingExamples();
            // - Delegates, lambdas, anonymous methods
            (new ProgramFlow()).RunLambdasExamples();


            // Implement exception handling
            ((new ExceptionHandling())).RunExceptionHandlingExamples();


            Console.WriteLine("Press any key ...");
            Console.ReadKey();
        }
    }
}
