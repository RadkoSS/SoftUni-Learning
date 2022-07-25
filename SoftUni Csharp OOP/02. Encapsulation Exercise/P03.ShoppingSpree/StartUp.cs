namespace ShoppingSpree
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Models;

    public class StartUp
    {
        static void Main()
        {
            string[] people = Console.ReadLine().Split(';', '=');

            string[] products = Console.ReadLine().Split(new char[] { ' ', ';', '='}, StringSplitOptions.RemoveEmptyEntries);

            List<Person> peopleList = new List<Person>();
            List<Product> productsList = new List<Product>();

            try
            {

                for (int i = 0; i < people.Length; i += 2)
                {
                    string clientName = people[i];
                    decimal clientMoney = decimal.Parse(people[i + 1]);

                    peopleList.Add(new Person(clientName, clientMoney));
                }

                for (int i = 0; i < products.Length; i += 2)
                {
                    string productName = products[i];
                    decimal productCost = decimal.Parse(products[i + 1]);

                    productsList.Add(new Product(productName, productCost));
                }

                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] info = command.Split();

                    string clientName = info[0];

                    string productName = info[1];

                    Person searchedClient = peopleList.FirstOrDefault(client => client.Name == clientName);

                    Product searchedProduct = productsList.FirstOrDefault(product => product.Name == productName);

                    if (searchedProduct != null)
                    {
                        if (searchedClient != null)
                        {
                            bool canBuy = searchedClient.BuyProduct(searchedProduct);
                            if (canBuy)
                            {
                                Console.WriteLine($"{clientName} bought {productName}");
                            }
                            else
                            {
                                Console.WriteLine($"{clientName} can't afford {searchedProduct}");
                            }
                        }
                    }
                }

                Console.WriteLine(string.Join(Environment.NewLine, peopleList));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
