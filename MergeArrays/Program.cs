using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace MergeArrays;

public class Program
{
    public static void Main(string[] args)
    {
        string[] names1 = { "andy", "bart", "zach" };
        string[] names2 = { "ben", "wisdom", "xavier" };

        var sortedNames = MergeSortedArrays(names1, names2);
    }

    public static int[] MergeSortedArrays(int[] array1, int[] array2)
    {
        List<int> sorted = [];
        int index1 = 0;
        int index2 = 0;
        int indexSorted = 0;
        while (sorted.Count != array1.Length + array2.Length)
        {
            if (array1[index1] < array2[index2])
            {
                sorted[indexSorted] = array1[index1];
                index1 += 1;
                indexSorted += 1;
            }
            else
            {
                sorted[indexSorted] = array2[index2];
                index2 += 1;
                indexSorted += 1;
            }
        }
        return sorted.ToArray();
    }

    private static bool IsSorted(int[] array)
    {
        bool isSorted = true;
        int index = 0;
        while (!isSorted)
        {
            if (array[index] < array[index+1])
            {
                continue;
            }
            else
            {
                isSorted = false;
            }
        }
        return isSorted;
    }

    public static T[] MergeSortedArrays<T>(T[] array1, T[] array2) where T : IComparable<T>
    {
        T[] result = new T[array1.Length + array2.Length];
        int index1 = 0;
        int index2 = 0;
        int indexResult = 0;

        while (indexResult != array1.Length + array2.Length)
        {
            if (array1[index1].CompareTo(array2[index2]) <= 0)
            {
                result[indexResult] = array1[index1];
                index1 += 1;
                indexResult += 1;
            }
            else
            {
                result[indexResult] = array2[index2];
                index2 += 1;
                indexResult += 1;
            }
        }
        return result;
    }
}

