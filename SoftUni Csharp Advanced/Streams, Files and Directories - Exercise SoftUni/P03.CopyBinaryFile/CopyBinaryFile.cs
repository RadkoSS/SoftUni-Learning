namespace CopyBinaryFile
{
    using System.IO;
    using System.Linq;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {

            using (BinaryReader input = new BinaryReader(File.Open(inputFilePath, FileMode.Open)))
            {

                using (BinaryWriter output = new BinaryWriter(File.Open(outputFilePath, FileMode.OpenOrCreate)))
                {
                    byte[] buffer = new byte[1024];

                    int bytesRead = 0;

                    while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if (bytesRead < buffer.Length)
                        {
                            buffer = buffer.Take(bytesRead).ToArray();
                        }

                        output.Write(buffer, 0, bytesRead);
                    }
                }

            }

        }
    }
}

