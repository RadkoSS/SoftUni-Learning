namespace P04.BubSort
{
    internal class Program
    {
        private static int[] array = null!;

        private static void Main()
        {
            array = new[] { 190, 21, 3213423, 42, 51, 42, 36, 87, 98, 99 };

            BubbleSort(array.Length);
        }

        private static void BubbleSort(int end)
        {
            if (end <= 1)
            {
                Console.WriteLine(string.Join(", ", array));
                return;
            }

            BubbleSortInner(0, end);
            BubbleSort(end - 1);
        }

        private static void BubbleSortInner(int index, int end)
        {
            if (index >= end - 1)
            {
                return;
            }

            var currentItem = array[index];
            var nextItem = array[index + 1];

            if (currentItem > nextItem)
            {
                array[index] = nextItem;
                array[index + 1] = currentItem;
            }

            BubbleSortInner(index + 1, end);
        }
    }
}