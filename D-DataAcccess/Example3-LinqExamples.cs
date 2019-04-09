using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class LinqExamples
    {
        #region LINQ Select

        /// <summary>
        /// 
        /// </summary>
        public void RunLinqSelectExamples()
        {
            // --------------------------------------------------------------------------------------------
            // - Enumerable.Select https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select
            //   TODO
            // - Select clause in C# https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/select-clause
            //   TODO

            PizzaService service = PizzaService.Create();

            // --------------------------------------------------------------------------------------------
            // Creating an anonymus object 
            var result = service.Pizzas.Select(a => new {
                a.Name,
                a.Price,
            });
            Console.Write("[LinQ.Select] Results = ");
            foreach (var entry in result)
            {
                Console.Write("[Name = {0}, Price = {1}], ", entry.Name, entry.Price);
            }
            Console.WriteLine();

            // --------------------------------------------------------------------------------------------
            // Changing the property names in the anonymus object
            var result2 = service.Pizzas.Select(a => new {
                Pizza = a.Name,
                Cost = a.Price,
            });
            Console.Write("[LinQ.Select2] Results = ");
            foreach (var entry in result2)
            {
                Console.Write("[Pizza = {0}, Cost = {1}], ", entry.Pizza, entry.Cost);
            }
            Console.WriteLine();

            // --------------------------------------------------------------------------------------------
            // Additional expressions while creating the object
            var result3 = service.Customers.Select(a => new {
                Name = a.Name,
                Address = a.Address ?? "None",
            });
            Console.Write("[LinQ.Select3] Results = ");
            foreach (var entry in result3)
            {
                Console.Write("[Name = {0}, Address = {1}], ", entry.Name, entry.Address);
            }
            Console.WriteLine();

            // --------------------------------------------------------------------------------------------
            // Changing the names in the resulting object
            var result4 = service.Pizzas.Select(a => a.Name);
            Console.WriteLine("[LinQ.Select4] Results = {0}", string.Join(", ", result4));

            // --------------------------------------------------------------------------------------------
            // And the real deal
            var result5 = from p in service.Pizzas
                          select new {
                              p.Name,
                              p.Price,
                          };
            Console.Write("[LinQ.Select5] Results = ");
            foreach (var entry in result5)
            {
                Console.Write("[Name = {0}, Price = {1}], ", entry.Name, entry.Price);
            }
            Console.WriteLine();
        }

        #endregion

        #region LINQ clause vs methods

        /// <summary>
        /// 
        /// </summary>
        public void RunLinqClauseExamples()
        {
            // --------------------------------------------------------------------------------------------
            // - from clause https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/from-clause
            // - where clause https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-clause
            // - select clause https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/select-clause
            // - group clause https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/group-clause
            // - orderby clause https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/orderby-clause
            // - join clause https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/join-clause
            // - let clause https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/let-clause

            PizzaService service = PizzaService.Create();

            // --------------------------------------------------------------------------------------------
            // orderby clause example
            {
                // -----------------------------------------
                // Ascending
                var result = from pizza in service.Pizzas
                             where pizza.Ingredients.Length > 3
                             orderby pizza.Name
                             select pizza;

                var result2 = service.Pizzas
                    .Where(pizza => pizza.Ingredients.Length > 3)
                    .OrderBy(pizza => pizza.Name);

                // -----------------------------------------
                // Descending
                var result3 = from pizza in service.Pizzas
                              where pizza.Ingredients.Length > 3
                              orderby pizza.Name descending
                              select pizza;

                var result4 = service.Pizzas
                    .Where(pizza => pizza.Ingredients.Length > 3)
                    .OrderBy(pizza => pizza.Name)
                    .Reverse();
            }

            // --------------------------------------------------------------------------------------------
            // join clause example
            {
                var result = from pizza in service.Pizzas
                             join customer in service.Customers on pizza.Name equals customer.Favorite
                             select new { Pizza = pizza.Name, Customer = customer.Name };

                var result2 = service.Pizzas.Join(
                    service.Customers,
                    pizza => pizza.Name,
                    customer => customer.Favorite,
                    (pizza, customer) => new { Pizza = pizza.Name, Customer = customer.Name });
            }

            // --------------------------------------------------------------------------------------------
            // group clause example
            {
                var result = from customer in service.Customers
                             group customer by customer.Favorite;

                var result2 = service.Customers
                    .GroupBy(customer => customer.Favorite);
            }
        }

        #endregion
    }
}
