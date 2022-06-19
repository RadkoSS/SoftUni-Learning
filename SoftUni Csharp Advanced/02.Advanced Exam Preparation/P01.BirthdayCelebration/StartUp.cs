using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.BirthdayCelebration
{
    public class StartUp
    {
        static void Main()
        {
            int[] guestsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] platesArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> plates = new Stack<int>(platesArray);

            Queue<int> guests = new Queue<int>(guestsArray);

            var wastedGramsOfFood = 0;

            while (plates.Count > 0 && guests.Count > 0)
            {
                var currentPlate = plates.Pop();
                var currentGuest = guests.Peek();

                var currentGuestValue = currentGuest - currentPlate;

                if (currentGuestValue <= 0)
                {
                    wastedGramsOfFood += currentGuestValue;
                    guests.Dequeue();
                }
                else
                {
                    BringNewPlate(ref currentGuestValue, ref plates, ref guests, ref wastedGramsOfFood);
                }
            }

            PrintResult(plates, guests, wastedGramsOfFood);
        }

        static void BringNewPlate(ref int currentGuestValue, ref Stack<int> plates, ref Queue<int> guests, ref int wastedGramsOfFood)
        {
            while (currentGuestValue > 0)
            {
                if (plates.Count == 0)
                {
                    break;
                }
                var nextPlate = plates.Pop();

                if (nextPlate >= currentGuestValue)
                {
                    currentGuestValue -= nextPlate;
                    wastedGramsOfFood += currentGuestValue;
                    guests.Dequeue();
                }
                else
                {
                    currentGuestValue -= nextPlate;
                }
            }

        }

        static void PrintResult(Stack<int> plates, Queue<int> guests, int wastedGramsOfFood)
        {
            if (plates.Count > 0)
                Console.WriteLine($"Plates: {string.Join(' ', plates)}");

            else if (guests.Count > 0)
                Console.WriteLine($"Guests: {string.Join(' ', guests)}");

            Console.WriteLine($"Wasted grams of food: {Math.Abs(wastedGramsOfFood)}");
        }
    }
}
