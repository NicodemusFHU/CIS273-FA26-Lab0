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
        int[] Sorted = [.. array1, .. array2];
        int Index1 = 0;
        int Index2 = 0;
        int IndexSorted = 0;

        while (Index1 < array1.Length | Index2 < array2.Length)
        {
            if (Index1 == array1.Length)
            {
                Console.WriteLine($"{IndexSorted} {Sorted.Length}");
                Sorted[IndexSorted] = array2[Index2];
                Index2++;
                IndexSorted++;
            }
            else if(Index2 == array2.Length)
            {
                Console.WriteLine($"{IndexSorted} {Sorted.Length}");
                Sorted[IndexSorted] = array1[Index1];
                Index1++;
                IndexSorted++;
            }
            else if(array1[Index1] < array2[Index2])
            {
                Console.WriteLine($"{IndexSorted} {Sorted.Length}");
                Sorted[IndexSorted] = array1[Index1];
                Index1++;
                IndexSorted++;
            }
            else
            {
                Console.WriteLine($"{IndexSorted} {Sorted.Length}");
                Sorted[IndexSorted] = array2[Index2];
                Index2++;
                IndexSorted++;
            }
        }
        return Sorted;
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

