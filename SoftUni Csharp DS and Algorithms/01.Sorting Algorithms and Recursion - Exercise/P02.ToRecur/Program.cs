namespace P02.ToRecur;

internal class Program
{
    private static void Main()
    {
        int nestingCount = int.Parse(Console.ReadLine()!);

        SimulateLoops(nestingCount, 1, new List<int>());
    }

    private static void SimulateLoops(int nestingCount, int columnIndex, IList<int> values)
    {
        if (columnIndex > nestingCount) // base case: if the columnIndex is greater than the nestingCount, print the values
        {
            Console.WriteLine(string.Join(" ", values));
            return;
        }

        for (int row = 1; row <= nestingCount; row++)
        {
            values.Add(row); // append the current value to the queue
            SimulateLoops(nestingCount, columnIndex + 1, values); // recursive call with increased columnIndex
            values.RemoveAt(values.Count - 1); // remove the last value before the next iteration
        }
    }
}