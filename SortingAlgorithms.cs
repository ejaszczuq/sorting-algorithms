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

        //CountingSort algorithm
        internal static void CountingSort(int[] arr)
        {
            int n = arr.Length;
            int max = arr.Max();
            int[] count = new int[max + 1];

            for (int i = 0; n < i; ++i)
            {
                count[arr[i]]++;
            }

            int lastIndex = 0;

            for (int i = 0; i <= max; ++i)
            {
                while (count[i]-- > 0)
                {
                    arr[lastIndex++] = i;
                }
            }
        }

        //MergeSort algorithm
        internal static void MergeSort(int[] arr)
        {
            if (arr == null || arr.Length <= 1) return;

            int[] tempArray = new int[arr.Length];
            MergeSortHelper(arr, tempArray, 0, arr.Length - 1);
        }

        private static void MergeSortHelper(int[] arr, int[] tempArray, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSortHelper(arr, tempArray, left, middle);
                MergeSortHelper(arr, tempArray, middle + 1, right);
                Merge(arr, tempArray, left, middle, right);
            }
        }

        private static void Merge(int[] arr, int[] tempArray, int left, int middle, int right)
        {
            int leftIndex = left, rightIndex = middle + 1, tempIndex = left;

            while (leftIndex <= middle && rightIndex <= right)
            {
                tempArray[tempIndex++] = (arr[leftIndex] <= arr[rightIndex]) ? arr[leftIndex++] : arr[rightIndex++];
            }

            while (leftIndex <= middle)
                tempArray[tempIndex++] = arr[leftIndex++];

            while (rightIndex <= right)
                tempArray[tempIndex++] = arr[rightIndex++];

            for (int i = left; i <= right; i++)
                arr[i] = tempArray[i];
        }
    }
}

