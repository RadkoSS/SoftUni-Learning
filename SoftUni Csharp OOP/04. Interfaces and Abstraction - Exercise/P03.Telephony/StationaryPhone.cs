namespace Telephony
{
    using System;

    public class StationaryPhone : ICallable
    {
        public string CallNumber(string number)
        {
            foreach (var character in number)
            {
                if (!char.IsDigit(character))
                {
                    throw new Exception("There must be only digits in a phone number.");
                }
            }
            return $"Dialing... {number}";
        }
    }
}
