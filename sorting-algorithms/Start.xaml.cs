using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace sorting_algorithms
{
    public partial class Start : Page
    {
        private Random random = new Random();

        public Start()
        {
            InitializeComponent();
            InitializeTbNumbers();
        }

        private void InitializeTbNumbers()
        {
            if (DataStorage.numbers.Sum() > 0)
            {
                tbNumbers.Text = string.Join(", ", DataStorage.numbers);
            }
            else
            {
                tbNumbers.Text = "numbers";
            }
        }

        private void Navigate(Page page)
        {
            NavigationService.Navigate(page);
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < DataStorage.numbers.Length; i++)
                {
                    DataStorage.numbers[i] = random.Next(1000);
                }

                string allNumbers = string.Join(", ", DataStorage.numbers);

                tbNumbers.Text = allNumbers;
                int[] result;

                if (TryParseIntArray(tbNumbers.Text, out result))
                {
                    DataStorage.numbers = result;
                }
                else
                {
                    MessageBox.Show("Failed to parse numbers from tbNumbers.Text.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool TryParseIntArray(string input, out int[] result)
        {
            string[] numberStrings = input.Split(',');

            result = new int[numberStrings.Length];

            for (int i = 0; i < numberStrings.Length; i++)
            {
                if (!int.TryParse(numberStrings[i], out result[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public delegate void SortingAlgorithmDelegate(int[] array);

        public void ExecuteSortingAlgorithm(string algorithmName, SortingAlgorithmDelegate sortingAlgorithm)
        {
            int[] clonedNumbers = (int[])DataStorage.numbers.Clone();

            var stopwatch = Stopwatch.StartNew();
            sortingAlgorithm(clonedNumbers);
            stopwatch.Stop();

            var sortedNumbersPage = new SortedNumbersPage(
              string.Join(", ", clonedNumbers),
              algorithmName,
              stopwatch.ElapsedMilliseconds
          );

            Navigate(sortedNumbersPage);
        }

        // QuickSort algorithm
        private void QuickSortButton_Click(object sender, RoutedEventArgs e)
        {
            ExecuteSortingAlgorithm("QuickSort", SortingAlgorithms.QuickSort);
        }

        // BubbleSort algorithm
        private void BubbleSortButton_Click(object sender, RoutedEventArgs e)
        {
            ExecuteSortingAlgorithm("BubbleSort", SortingAlgorithms.BubbleSort);
        }


        // InsertionSort algorithm
        private void InsertionSortButton_Click(object sender, RoutedEventArgs e)
        {
            ExecuteSortingAlgorithm("InsertionSort", SortingAlgorithms.InsertionSort);
        }

        // CountingSort algorithm
        private void CountingSortButton_Click(object sender, RoutedEventArgs e)
        {
            ExecuteSortingAlgorithm("CountingSort", SortingAlgorithms.CountingSort);
        }

        // MergeSort algorithm
        private void MergeSortButton_Click(object sender, RoutedEventArgs e)
        {
            ExecuteSortingAlgorithm("MergeSort", SortingAlgorithms.MergeSort);
        }

        // SelectionSort algorithm
        private void SelectionSortButton_Click(object sender, RoutedEventArgs e)
        {
            ExecuteSortingAlgorithm("SelectionSort", SortingAlgorithms.SelectionSort);
        }
    }
}
