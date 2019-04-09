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
                    },
                    new Pizza {
                        Name = "Kebab",
                        Price = 6.5f,
                        Ingredients = new Ingredient[] {
                            new Ingredient { Name = "Dough" },
                            new Ingredient { Name = "Tomato Sauce" },
                            new Ingredient { Name = "Kebab" },
                            new Ingredient { Name = "Cheese" },
                            new Ingredient { Name = "Kebab Sauce" },
                        }
                    },
                    new Pizza {
                        Name = "Broccoli",
                        Price = 6.0f,
                        Ingredients = new Ingredient[] {
                            new Ingredient { Name = "Dough" },
                            new Ingredient { Name = "Tomato Sauce" },
                            new Ingredient { Name = "Broccoli" },
                            new Ingredient { Name = "Cheese" },
                        }
                    },
                    new Pizza {
                        Name = "Meatball",
                        Price = 6.5f,
                        Ingredients = new Ingredient[] {
                            new Ingredient { Name = "Dough" },
                            new Ingredient { Name = "Tomato Sauce" },
                            new Ingredient { Name = "Meatball" },
                            new Ingredient { Name = "Cheese" },
                        }
                    },
                    new Pizza {
                        Name = "Pepperoni",
                        Price = 6.5f,
                        Ingredients = new Ingredient[] {
                            new Ingredient { Name = "Dough" },
                            new Ingredient { Name = "Tomato Sauce" },
                            new Ingredient { Name = "Pepperoni" },
                            new Ingredient { Name = "Salami" },
                            new Ingredient { Name = "Cheese" },
                        }
                    },
                },
                Customers = new Customer[]
                {
                    new Customer
                    {
                        Name = "Barney",
                        Address = "Bedrock",
                        Favorite = "Broccoli",
                        FavoriteCount = 58,
                    },
                    new Customer
                    {
                        Name = "Homer",
                        Address = "Springfield",
                        Favorite = "Meatball",
                        FavoriteCount = 367,
                    },
                    new Customer
                    {
                        Name = "Luke",
                        Address = "Tatooine",
                        Favorite = "Margherita",
                        FavoriteCount = 2,
                    },
                    new Customer
                    {
                        Name = "Sabrina",
                        Address = "Greendale",
                        Favorite = "Pepperoni",
                        FavoriteCount = 666,
                    },
                    new Customer
                    {
                        Name = "Papa",
                        Address = "Smurf Village",
                        Favorite = "Classic",
                        FavoriteCount = 7,
                    },
                    new Customer
                    {
                        Name = "Papa",
                        Address = "Smurf Village",
                        Favorite = "Classic",
                        FavoriteCount = 7,
                    },
                    new Customer
                    {
                        Name = "Unknown",
                        Address = null,
                        Favorite = "Margherita",
                        FavoriteCount = 0,
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

        public string Favorite { get; set; }

        public int FavoriteCount { get; set; }
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
