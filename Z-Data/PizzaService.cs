using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    [Serializable]
    public class PizzaService
    {
        public Pizza[] Pizzas { get; set; }

        public Customer[] Customers { get; set; }

        public static PizzaService Create()
        {
            return (new PizzaService
            {
                Pizzas = new Pizza[]
                {
                    new Pizza {
                        Name = "Margherita",
                        Price = 5.5f,
                        Ingredients = new Ingredient[] {
                            new Ingredient { Name = "Dough" },
                            new Ingredient { Name = "Tomato Sauce" },
                            new Ingredient { Name = "Mozzarella" }
                        }
                    },
                    new Pizza {
                        Name = "Classic",
                        Price = 6.0f,
                        Ingredients = new Ingredient[] {
                            new Ingredient { Name = "Dough" },
                            new Ingredient { Name = "Tomato Sauce" },
                            new Ingredient { Name = "Ham" },
                            new Ingredient { Name = "Mushrooms" },
                            new Ingredient { Name = "Cheese" }
                        }
                    },                },
                Customers = new Customer[]
                {
                    new Customer
                    {
                        Name = "Barney",
                        Address = "Bedrock",
                        PizzaCount = 5,
                    },
                    new Customer
                    {
                        Name = "Homer",
                        Address = "Springfield",
                        PizzaCount = 367,
                    },
                    new Customer
                    {
                        Name = "Luke",
                        Address = "Tatooine",
                        PizzaCount = 2,
                    }
                }
            });
        }
    }

    [Serializable]
    public class Customer
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int PizzaCount { get; set; }
    }

    [Serializable]
    public class Pizza
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public Ingredient[] Ingredients { get; set; }
    }

    [Serializable]
    public class Ingredient
    {
        public string Name { get; set; }
    }
}
