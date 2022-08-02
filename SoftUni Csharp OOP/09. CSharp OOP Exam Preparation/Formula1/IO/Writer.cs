namespace Formula1.IO
{
    using System;
    using System.Text;

    using Contracts;

    public class Writer : IWriter
    {
        private readonly StringBuilder _output;

        public Writer()
        {
            this._output = new StringBuilder();
        }

        public void Write(string message)
        {
            Console.Write(message);

            this._output.Append(message);
        }

        public string WriteAllLines() => this._output.ToString().TrimEnd();

        public void WriteLine(string message)
        {
            Console.WriteLine(message);

            this._output.AppendLine(message);
        }
    }
}
