namespace P5MergeSort;

using System;

internal class MergeSort<T> where T : IComparable
{
    private T[] auxiliaryArr = null!;

    internal void Sort(T[] array)
    {
        auxiliaryArr = new T[array.Length];
        Sort(array, 0, array.Length - 1);
        Console.WriteLine(string.Join(" ", array));
    }

    private void Sort(T[] array, int low, int high)
    {
        if (low >= high)
        {
            return;
        }

        var mid = low + (high - low) / 2;

        Sort(array, low, mid);
        Sort(array, mid + 1, high);
        Merge(array, low, mid, high);
    }

    private void Merge(T[] array, int low, int mid, int high)
    {
        if (IsLess(array[mid], array[mid + 1]))
        {
            return;
        }

        for (int index = low; index <= high; index++)
        {
            auxiliaryArr[index] = array[index];
        }

        int i = low;
        int j = mid + 1;

        for (int k = low; k <= high; k++)
        {
            if (i > mid)
            {
                array[k] = auxiliaryArr[j++];
            }
            else if (j > high)
            {
                array[k] = auxiliaryArr[i++];
            }
            else if (IsLess(auxiliaryArr[j], auxiliaryArr[i]))
            {
                array[k] = auxiliaryArr[j++];
            }
            else
            {
                array[k] = auxiliaryArr[i++];
            }
        }
    }

    private bool IsLess(T firstElement, T secondElement)
        => firstElement.CompareTo(secondElement) < 0;
}