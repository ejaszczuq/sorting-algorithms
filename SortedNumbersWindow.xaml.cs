using System.Windows;

namespace sorting_algorithms
{
    public partial class SortedNumbersWindow : Window
    {
        public SortedNumbersWindow(string sortedNumbers, string algorithmName, long executionTime)
        {
            InitializeComponent();

            tbSortedNumbers.Text = $"Sorted Numbers: {sortedNumbers}";
            tbAlgorithmInfo.Text = $"Algorithm: {algorithmName}";
            tbExecutionTime.Text = $"Execution Time: {executionTime / 1000.0:F6} seconds"; // Formatowanie czasu do 6 miejsc po przecinku
        }
    }
}
