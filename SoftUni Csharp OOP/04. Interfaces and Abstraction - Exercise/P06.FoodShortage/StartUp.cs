namespace FoodShortage
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Models;
    using Models.Contracts;

    public class StartUp
    {
        static void Main()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            ICollection<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] commandStrings = Console.ReadLine().Split();

                if (commandStrings.Length == 3)
                {
                    buyers.Add(new Rebel(commandStrings[0], int.Parse(commandStrings[1]), commandStrings[2]));
                }
                else if (commandStrings.Length == 4)
                {
                    buyers.Add(new Citizen(commandStrings[0], int.Parse(commandStrings[1]), commandStrings[2], commandStrings[3]));
                }
            }

            string name;
            while ((name = Console.ReadLine()) != "End")
            {
                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == name);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            int totalFoodQuantity = 0;

            foreach (var buyer in buyers)
            {
                totalFoodQuantity += buyer.Food;
            }

            Console.WriteLine(totalFoodQuantity);
        }
    }
}
