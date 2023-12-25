using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting_algorithms
{
    internal static class SortingAlghoritms 
    {
        //QuickSort algorithm
        internal static void QuickSort(int[] arr, int first, int last)
        {
            if (first < last)
            {
                int partitionIndex = Partition(arr, first, last);

                QuickSort(arr, first, partitionIndex - 1);
                QuickSort(arr, partitionIndex + 1, last);
            }
        }

        internal static int Partition(int[] arr, int first, int last)
        {
            int pivot = arr[last];
            int i = first - 1;

            for (int j = first; j < last; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int tempPivot = arr[i + 1];
            arr[i + 1] = arr[last];
            arr[last] = tempPivot;

            return i + 1;
        }

        //BubbleSort algorithm
        internal static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        //InsertionSort algorithm
        internal static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }
    }
}
