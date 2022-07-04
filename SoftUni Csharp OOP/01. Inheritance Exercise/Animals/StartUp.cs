namespace Animals
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var animals = new List<Animal>();

            var animalType = string.Empty;

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    var animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    var animalName = animalInfo[0];
                    var animalAge = int.Parse(animalInfo[1]);
                    var animalGender = animalInfo[2];

                    Animal animal = null;

                    if (animalType == "Dog")
                    {
                        animal = new Dog(animalName, animalAge, animalGender);
                    }

                    else if (animalType == "Cat")
                    {
                        animal = new Cat(animalName, animalAge, animalGender);
                    }

                    else if (animalType == "Frog")
                    {
                        animal = new Cat(animalName, animalAge, animalGender);
                    }

                    else if (animalType == "Kitten")
                    {
                        animal = new Kitten(animalName, animalAge);
                    }

                    else if (animalType == "Tomcat")
                    {
                        animal = new Tomcat(animalName, animalAge);
                    }

                    else
                    {
                        throw new Exception("Invalid type of animal!");
                    }

                    animals.Add(animal);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, animals));
        }
    }
}
