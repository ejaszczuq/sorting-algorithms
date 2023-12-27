using System;
using System.Windows;
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
            tbAlgorithmInfo.Text = $"Algorithm: {algorithmInfo}";
            tbExecutionTime.Text = $"Execution Time: {executionTime} ms";
        }

        private void CustomInitializeComponent()
        {
            // Initialize components
            tbSortedNumbers = new TextBox();
            tbAlgorithmInfo = new TextBox();
            tbExecutionTime = new TextBox();

            // Button (back) Styles
            buttonStyle = new Style(typeof(Button));
            buttonStyle.Setters.Add(new Setter(Button.BackgroundProperty, Brushes.LightBlue));
            buttonStyle.Setters.Add(new Setter(Button.ForegroundProperty, Brushes.DarkBlue));

            buttonStyle.Setters.Add(new Setter(Button.HeightProperty, 30.0));
            buttonStyle.Setters.Add(new Setter(Button.WidthProperty, 60.0));

            buttonStyle.Setters.Add(new Setter(Button.MarginProperty, new Thickness(0, 70, 0, 0)));

            Button back = new Button();
            back.Command = NavigationCommands.BrowseBack;
            back.Content = "Back";
            back.Style = buttonStyle;



            // Settings for TextBoxes
            tbSortedNumbers.IsReadOnly = true;
            tbAlgorithmInfo.IsReadOnly = true;
            tbExecutionTime.IsReadOnly = true;

            // Allow text wrapping in tbSortedNumbers
            tbSortedNumbers.TextWrapping = TextWrapping.Wrap;

            // Set background and font color for tbSortedNumbers
            tbSortedNumbers.Height = 200;
            tbSortedNumbers.Width = 500;

            tbSortedNumbers.Background = new SolidColorBrush(Color.FromRgb(190, 226, 241)); // #FFBEE2F1
            tbSortedNumbers.Foreground = new SolidColorBrush(Color.FromRgb(26, 105, 115)); // #FF1A6973
            tbSortedNumbers.BorderBrush = new SolidColorBrush(Color.FromRgb(26, 105, 115)); // #FF1A6973
            tbSortedNumbers.BorderThickness = new Thickness(2);
            tbSortedNumbers.TextAlignment = TextAlignment.Center;
            tbSortedNumbers.VerticalAlignment = VerticalAlignment.Top;
            tbSortedNumbers.HorizontalAlignment = HorizontalAlignment.Center;
            tbSortedNumbers.Margin = new Thickness(0, 45, 0, -10);

            // Add to the grid
            Grid grid = new Grid();
            grid.Background = new SolidColorBrush(Colors.White);
            // Settings for the grid
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }); // Auto-sized row for tbSortedNumbers
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }); // Auto-sized row for algorithm info and execution time
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Auto-sized row for the back button

            // Settings for tbSortedNumbers
            Grid.SetRow(tbSortedNumbers, 0);
            grid.Children.Add(tbSortedNumbers);

            // Grid for algorithm info and execution time
            Grid infoGrid = new Grid();
            infoGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); // Left side
            infoGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); // Right side
            Grid.SetRow(infoGrid, 1);
            grid.Children.Add(infoGrid);

            // Settings for tbAlgorithmInfo
            tbAlgorithmInfo.Margin = new Thickness(142, 10, 10, 0); 
            tbAlgorithmInfo.HorizontalAlignment = HorizontalAlignment.Left;
            infoGrid.Children.Add(tbAlgorithmInfo);

            // Settings for tbExecutionTime
            tbExecutionTime.Margin = new Thickness(10, 10, 142, 0); 
            tbExecutionTime.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetColumn(tbExecutionTime, 1);
            infoGrid.Children.Add(tbExecutionTime);

            // Settings for back button
            Grid.SetRow(back, 2);
            grid.Children.Add(back);

            Content = grid;
        }

        // Declarations of TextBoxes
        private TextBox tbSortedNumbers;
        private TextBox tbAlgorithmInfo;
        private TextBox tbExecutionTime;
        private Style buttonStyle;
    }
}
