using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sorting_algorithms
{
    public partial class MainWindow : Window
    {
        private int[] numbers = new int[10];
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }
        public int Length => numbers.Length;
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
                //Clone the array to avoid modifying the original array
                int[] clonedNumbers = (int[])numbers.Clone();

                //Perform quicksort
                QuickSort(clonedNumbers, 0, clonedNumbers.Length - 1);

                //Display the sorted array
                tbNumbers.Text = string.Join(", ", clonedNumbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Quicksort algorithm
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

                    //Swap arr[i] and arr[j]
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            //Swap arr[i+1] and arr[last] (pivot)
            int tempPivot = arr[i + 1];
            arr[i + 1] = arr[last];
            arr[last] = tempPivot;

            return i + 1;
        }

        //Bubblesort algorithm
        private void BubbleSort()
        {
            bool swapped;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;

                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }
        }


        private void BubbleSortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BubbleSort();

                //Display the sorted array
                tbNumbers.Text = string.Join(", ", numbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}




