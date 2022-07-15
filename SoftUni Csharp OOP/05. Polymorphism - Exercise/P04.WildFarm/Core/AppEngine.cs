namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using IO.Interfaces;

    using Models.Food;
    using Models.Animals;
    using Factories;
    using Factories.Interfaces;

    using Exceptions;

    public class AppEngine : IEngine
    {
        private readonly IWriter writer;

        private readonly IReader reader;

        private readonly IAnimalFactory animalFactory;

        private readonly IFoodFactory foodFactory;

        private readonly ICollection<Animal> animals;


        private AppEngine()
        {
            this.animals = new List<Animal>();

            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }

        public AppEngine(IWriter writer, IReader reader) : this()
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void RunAplication()
        {
            var command = string.Empty;

            while ((command = this.reader.ReadLine()) != "End")
            {
                try
                {
                    var animalInfo = command.Split();
                    var foodInfo = this.reader.ReadLine().Split();

                    var foodType = foodInfo[0];
                    var foodQuantity = int.Parse(foodInfo[1]);

                    Animal animal = CreateAnimalWithFactory(animalInfo);

                    Food food = this.foodFactory.CreateFood(foodType, foodQuantity);

                    this.writer.WriteLine(animal.AskForFood());

                    this.animals.Add(animal);

                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
                catch (InvalidFactoryTypeException ifte)
                {
                    this.writer.WriteLine(ifte.Message);
                }
                catch (InvalidTypeOfFoodException itofe)
                {
                    this.writer.WriteLine(itofe.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    this.writer.WriteLine(ioe.Message);
                }
                catch (IndexOutOfRangeException)
                {
                    this.writer.WriteLine("Invalid input!");
                }
                catch (FormatException)
                {
                    this.writer.WriteLine("You are giving too many parameters! Input is invalid.");
                }
            }

            PrintResult(this.animals);
        }

        private Animal CreateAnimalWithFactory(string[] animalInfo)
        {
            var animalType = animalInfo[0];
            var animalName = animalInfo[1];
            var animalWeight = double.Parse(animalInfo[2]);

            Animal animal;

            if (animalInfo.Length == 4)
            {
                var lastParam = animalInfo[3];

                animal = this.animalFactory.CreateAnimal(animalType, animalName, animalWeight, lastParam);
            }
            else if (animalInfo.Length == 5)
            {
                var thirdAnimalParameter = animalInfo[3];
                var lastParam = animalInfo[4];

                animal = this.animalFactory.CreateAnimal(animalType, animalName, animalWeight, thirdAnimalParameter, lastParam);
            }
            else
            {
                throw new ArgumentException("Invalid input");
            }

            return animal;
        }

        private void PrintResult(ICollection<Animal> animalsList) => this.writer.WriteLine(string.Join(Environment.NewLine, animalsList));
    }
}
