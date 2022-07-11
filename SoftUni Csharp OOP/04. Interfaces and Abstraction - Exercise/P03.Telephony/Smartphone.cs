namespace Telephony
{
    using System;

    public class Smartphone : ICallable, IBrowsable
    {
        public string BrowseWebsite(string webSite)
        {
            foreach (var character in webSite)
            {
                if (char.IsDigit(character))
                {
                    throw new Exception($"There must not be any numbers in a site's URL.");
                }
            }
            return $"Browsing: {webSite}!";
        }

        public string CallNumber(string number)
        {
            foreach (var character in number)
            {
                if (!char.IsDigit(character))
                {
                    throw new Exception("There must be only digits in a phone number.");
                }
            }
            return $"Calling... {number}";
        }
    }
}