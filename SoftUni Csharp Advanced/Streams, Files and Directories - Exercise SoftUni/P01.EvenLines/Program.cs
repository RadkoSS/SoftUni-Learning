namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder textToPrint = new StringBuilder();

            using (StreamReader sirStanleyRoise = new StreamReader(inputFilePath))
            {
                string line = string.Empty;
                int lineNumber = 0;

                while ((line = sirStanleyRoise.ReadLine()) != null)
                {
                    if (lineNumber % 2 == 0)
                    {
                        line = ReplaceSymbols(line);

                        textToPrint.AppendLine(ReverseLine(line));
                    }

                    lineNumber++;
                }

            }

            return textToPrint.ToString();
        }

        static string ReplaceSymbols(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                char symbol = word[i];
                if (symbol == '?' || symbol == '!' || symbol == '.' || symbol == ',' || symbol == '-')
                {
                    word = word.Replace(symbol, '@');
                }
            }
            return word;
        }

        static string ReverseLine(string line)
        {
            return string.Join(' ', line.Split().Reverse());
        }
    }
}
