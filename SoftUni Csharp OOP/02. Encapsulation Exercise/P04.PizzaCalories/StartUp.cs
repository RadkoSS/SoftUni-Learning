namespace PizzaCalories
{
    using System;

    using Models;
    using Exceptions;
    using Models.Ingredients;

    public class StartUp
    {
        static void Main()
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();

                Pizza pizza = new Pizza(pizzaInfo[1]);

                string[] doughInfo = Console.ReadLine().Split();

                pizza.Dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] cmdArguments = command.Split();

                    string toppingType = cmdArguments[1];
                    double grams = double.Parse(cmdArguments[2]);

                    pizza.AddTopping(new Topping(toppingType, grams));
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (InvalidTypeOfIngredientException ingredientException)
            {
                Console.WriteLine(ingredientException.Message);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Invalid topping input!");
            }
        }
    }
}
