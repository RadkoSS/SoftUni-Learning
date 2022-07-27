namespace CommandPattern.IO
{
    using System;

    using Contracts;

    public class Writer : IWriter
    {
        public void Write(string input) => Console.Write(input);

        public void WriteLine(string input) => Console.WriteLine(input);

        public void WriteLine() => Console.WriteLine();

        public void ColorReset() => Console.ResetColor();
    }
}