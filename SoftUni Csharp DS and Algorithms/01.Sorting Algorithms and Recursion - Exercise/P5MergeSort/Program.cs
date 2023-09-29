namespace P5MergeSort;

internal class Program
{
    static void Main()
    {
        var mergeSort = new MergeSort<int>();
        var unsortedArray = new int[] { 5, 4, 2, -32, 100, 1, 4 };
        mergeSort.Sort(unsortedArray);
    }
}