using System;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace sorting_algorithms
{
    public partial class SortedNumbersPage : Page
    {
        public SortedNumbersPage(string sortedNumbers, string algorithmInfo, long executionTime)
        {
            CustomInitializeComponent();

            tbSortedNumbers.Text = sortedNumbers;
            tbAlgorithmInfo.Text = algorithmInfo;
            tbExecutionTime.Text = $"Execution Time: {executionTime} ms";
        }

        private void CustomInitializeComponent()
        {
            // Initialize components
            tbSortedNumbers = new TextBox();
            tbAlgorithmInfo = new TextBox();
            tbExecutionTime = new TextBox();

            Button back = new Button();
            back.Command = NavigationCommands.BrowseBack;
            back.Content = "Back";

            // Settings for TextBoxes
            tbSortedNumbers.IsReadOnly = true;
            tbAlgorithmInfo.IsReadOnly = true;
            tbExecutionTime.IsReadOnly = true;

            // Add to the grid
            Grid grid = new Grid();
            grid.Background = new SolidColorBrush(Colors.White);
            // Settings for the grid
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            // Settings for tbSortedNumbers
            Grid.SetColumn(tbSortedNumbers, 0);
            grid.Children.Add(tbSortedNumbers);

            // Settings for tbAlgorithmInfo
            Grid.SetColumn(tbAlgorithmInfo, 1);
            grid.Children.Add(tbAlgorithmInfo);

            // Settings for tbExecutionTime
            Grid.SetColumn(tbExecutionTime, 2);
            grid.Children.Add(tbExecutionTime);

            // Settings for back button
            Grid.SetColumn(back, 3);
            grid.Children.Add(back);

            Content = grid;
        }

        // Declarations of TextBoxes
        private TextBox tbSortedNumbers;
        private TextBox tbAlgorithmInfo;
        private TextBox tbExecutionTime;
    }
}
