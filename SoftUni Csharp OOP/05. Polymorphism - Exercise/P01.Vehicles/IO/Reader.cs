namespace Vehicles.IO
{
    using System;

    using Interfaces;

    public class Reader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
