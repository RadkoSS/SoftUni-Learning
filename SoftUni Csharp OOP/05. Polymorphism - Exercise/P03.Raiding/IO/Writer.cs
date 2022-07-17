namespace Raiding.IO
{
    using System;

    using Interfaces;

    public class Writer : IWriter
    {
        public void Write(string text) => Console.Write(text);

        public void WriteLine() => Console.WriteLine();

        public void WriteLine(string text) => Console.WriteLine(text);
    }
}
