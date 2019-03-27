using System;
using System.Collections.Generic;

namespace Example
{
    public class ProgramFlow
    {
        public ProgramFlow()
        {
        }

        #region Iteration Examples

        /// <summary>
        /// 
        /// </summary>
        public void RunIterationExamples()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };

            // -----------------------------------------
            // Normal for-loop
            Console.Write("[Iteration] For Array content = ");
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine();

            // -----------------------------------------
            // For-loop with special expressions
            LinkedList<int> linkedList = new LinkedList<int>(array);
            Console.Write("[Iteration] Linked list content = ");
            for (LinkedListNode<int> node = linkedList.First; node != null; node = node.Next)
            {
                Console.Write(node.Value);
            }
            Console.WriteLine();

            // -----------------------------------------
            // foreach-loop
            // - Can be used for all types which implement IEnumerable<> 
            Console.Write("[Iteration] Foreach Array content = ");
            foreach (int value in array)
            {
                Console.Write(value);
            }
            Console.WriteLine();

            // -----------------------------------------
            // Some implementations already contain for-methods
            List<int> list = new List<int>(array);
            Console.Write("[Iteration] Array content = ");
            list.ForEach(Console.Write);
            Console.WriteLine();

            // -----------------------------------------
            // while- and do-while-loops are similar just the execution of the condition is diffrent
            Console.Write("[Iteration] While and do while loops = ");
            int counter = 0;
            while ((counter++) < 8)
            {
                Console.Write(counter);
            }
            Console.Write("  ");
            counter = 0;
            do
            {
                Console.Write(counter);
            }
            while ((counter++) < 8);
            Console.WriteLine();
        }

        #endregion

        #region Decisions Examples

        public void RunDecisionsExamples()
        {
        }

        #endregion

        #region EventHandling Examples

        public void RunEventHandlingExamples()
        {
        }

        #endregion

        #region Lambdas Examples

        internal void RunLambdasExamples()
        {
        }

        #endregion

        #region Evaluate Expressions Examples

        internal void RunEvaluateExpressionsExamples()
        {
        }

        #endregion
    }
}