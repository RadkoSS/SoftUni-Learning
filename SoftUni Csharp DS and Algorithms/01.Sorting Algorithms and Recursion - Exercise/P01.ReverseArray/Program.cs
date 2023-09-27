namespace P01.ReverseArray;

internal class Program
{
    private static string[] numbersArray = null!;
    private static string[] reversedNumbersArray = null!;

    private static void Main()
    { 
        numbersArray = Console.ReadLine()!.Split(' ');
            
        reversedNumbersArray = new string[numbersArray.Length];

        ReverseArray(0);
    }

    private static void ReverseArray(int currentIndex)
    {
        if (currentIndex < 0 || currentIndex >= numbersArray.Length)
        {
            PrintResult();
            return;
        }

        reversedNumbersArray[numbersArray.Length - 1 - currentIndex] = numbersArray[currentIndex];

        ReverseArray(++currentIndex);
    }

    private static void PrintResult()
        => Console.WriteLine(string.Join(' ', reversedNumbersArray));
}