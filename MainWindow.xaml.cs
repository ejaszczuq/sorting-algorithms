using System;
using System.Diagnostics;
using System.Windows;

namespace sorting_algorithms
{
    public partial class MainWindow : Window
    {
        private int[] numbers = new int[1000];
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = random.Next(100);
                }

                string allNumbers = string.Join(", ", numbers);

                tbNumbers.Text = allNumbers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void QuickSortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] clonedNumbers = (int[])numbers.Clone();

                var stopwatch = Stopwatch.StartNew();
                QuickSort(clonedNumbers, 0, clonedNumbers.Length - 1);
                stopwatch.Stop();

                var sortedNumbersWindow = new SortedNumbersWindow(
                    string.Join(", ", clonedNumbers),
                    "QuickSort",
                    stopwatch.ElapsedMilliseconds
                );

                sortedNumbersWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void QuickSort(int[] arr, int first, int last)
        {
            if (first < last)
            {
                int partitionIndex = Partition(arr, first, last);

                QuickSort(arr, first, partitionIndex - 1);
                QuickSort(arr, partitionIndex + 1, last);
            }
        }

        private int Partition(int[] arr, int first, int last)
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

        private void BubbleSortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] clonedNumbers = (int[])numbers.Clone();

                var stopwatch = Stopwatch.StartNew();
                BubbleSort(clonedNumbers);
                stopwatch.Stop();

                var sortedNumbersWindow = new SortedNumbersWindow(
                    string.Join(", ", clonedNumbers),
                    "BubbleSort",
                    stopwatch.ElapsedMilliseconds
                );

                sortedNumbersWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BubbleSort(int[] arr)
        {
            bool swapped;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }
        }
    }
}
