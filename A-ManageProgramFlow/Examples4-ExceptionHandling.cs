using System;
using System.Linq;
using System.Threading.Tasks;

namespace Example
{
    public class ExceptionHandling
    {
        public void RunExceptionHandlingExamples()
        {
            // - Handle exception types including SQL exceptions, network exceptions, communication exceptions, network timeout exceptions
            // - use catch statements
            // - use base class of an exception
            // - implement try-catchfinally blocks
            // - throw exceptions
            // - rethrow an exception
            // - create custom exceptions
            // - handle inner exceptions


            // -----------------------------------------
            // AggregateException will be triggered when exceptions in tasks occur
            //   While the Wait on the task would only return the exception which occured
            //   in the task. "Task.WaitAll" will combine the exceptions occured in all tasks.
            try
            {
                Task firstTask = Task.Run(() =>
                {
                    throw (new Exception("Run"));
                });                
                Task secondTask = firstTask.ContinueWith(_ =>
                {
                    throw (new Exception("Continue"));
                });
                Task.WaitAll(firstTask, secondTask);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("[ExceptionHandling] Aggregate exception returns = {0}", 
                    string.Join(",", ex.InnerExceptions.Select(a => a.Message)));
            }
        }
    }
}