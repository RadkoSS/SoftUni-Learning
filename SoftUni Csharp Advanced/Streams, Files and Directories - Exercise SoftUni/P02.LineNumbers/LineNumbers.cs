namespace LineNumbers
{
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFile = @"..\..\..\text.txt";
            string outputFile = @"..\..\..\output.txt";

            ProcessLines(inputFile, outputFile);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string line = string.Empty;
                int lineNumber = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    int countOfLetters = 0;
                    int countOfPunctMarks = 0;

                    foreach (var symbol in line)
                    {
                        if (char.IsLetter(symbol))
                        {
                            countOfLetters++;
                        }
                        else if(char.IsPunctuation(symbol))
                        {
                            countOfPunctMarks++;
                        }
                    }

                    writer.WriteLine($"Line {lineNumber}: {line} ({countOfLetters})({countOfPunctMarks})");

                    lineNumber++;
                }

                reader.Close();

                writer.Close();
            }

        }

    }

}
