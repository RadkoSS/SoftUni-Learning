namespace Telephony
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            IBrowsable smartPhone = new Smartphone();

            ICallable stationaryPhone = new StationaryPhone();

            string[] phoneNumbers = Console.ReadLine().Split();

            string[] webSites = Console.ReadLine().Split();

            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.CallNumber(number));
                    }
                    else if (number.Length == 10)
                    {
                        Console.WriteLine(smartPhone.CallNumber(number));
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var url in webSites)
            {
                try
                {
                    Console.WriteLine(smartPhone.BrowseWebsite(url));
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
