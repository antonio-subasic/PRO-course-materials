using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace FibonacciGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private (int first, int second) _fibonacciNumbers;

        private TextBlock _pointsElement = new();
        private int _pointsValue = 0;
        private int _points
        {
            get => _pointsValue;
            set => _pointsElement.Text = $"{_pointsValue = value} Point{(_pointsValue == 1 ? "" : "s")}";
        }

        private StackPanel _heartsCollectionElement = new();

        private WrapPanel _numbersSequenceElement = new();

        private TextBox _numberInputElement = new();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += GenerateInitialState;
        }

        private void GenerateInitialState(object sender, RoutedEventArgs e)
        {
            _fibonacciNumbers = (0, 1);
            GlobalPanel.Children.Clear();

            // inserting bottom row (points, hearts, restart button)
            {
                _pointsElement = new TextBlock { Margin = new(15, 0, 0, 0) };
                _points = 0;
                var pointsStackPanel = new StackPanel { Children = { _pointsElement } };

                _heartsCollectionElement = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Children =
                    {
                        new TextBlock { Foreground = Brushes.Red, Text = "💗" },
                        new TextBlock { Foreground = Brushes.Red, Text = "💗" },
                        new TextBlock { Foreground = Brushes.Red, Text = "💗" }
                    }
                };
                Grid.SetColumn(_heartsCollectionElement, 1);

                var restartButton = new Button { Content = "Restart" };
                restartButton.Click += GenerateInitialState;
                var buttonStackPanel = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Children = { restartButton }
                };
                Grid.SetColumn(buttonStackPanel, 2);

                var grid = new Grid
                {
                    Margin = new(10),
                    ColumnDefinitions = { new(), new(), new() },
                    Children = { pointsStackPanel, _heartsCollectionElement, buttonStackPanel }
                };
                DockPanel.SetDock(grid, Dock.Bottom);

                GlobalPanel.Children.Add(grid);
            }

            // inserting numbers sequence (fibonacci sequence, number inputs)
            {
                _numberInputElement = new TextBox { Margin = new(0, 10, 0, 10), Focusable = true };
                _numberInputElement.KeyDown += (s, e) =>
                {
                    if (e.Key is Key.Enter or Key.Tab)
                    {
                        OnCheck(s, e);
                        Dispatcher.BeginInvoke(new Action(() => { _numberInputElement.Focus(); }), DispatcherPriority.Input);
                    }
                };
                Grid.SetColumn(_numberInputElement, 0);

                var checkButton = new Button { Content = "Check", Margin = new(15, 0, 0, 0), Focusable = false };
                checkButton.Click += OnCheck;
                Grid.SetColumn(checkButton, 1);

                var grid = new Grid
                {
                    ColumnDefinitions = { new(), new() },
                    Children = { _numberInputElement, checkButton }
                };

                _numbersSequenceElement = new WrapPanel
                {
                    Margin = new(10, 0, 10, 0),
                    Children = { GenerateGrid(0), GenerateGrid(1), grid }
                };

                GlobalPanel.Children.Add(_numbersSequenceElement);
            }
        }

        private Grid GenerateGrid(string number)
        {
            var textBlock = new TextBlock { Text = "➡" };
            Grid.SetColumn(textBlock, 1);

            return new Grid
            {
                ColumnDefinitions = { new(), new() },
                Children =
                {
                    new TextBox { Text = number, IsReadOnly = true },
                    textBlock,
                }
            };
        }

        private Grid GenerateGrid(int number) => GenerateGrid(number.ToString());

        private void OnCheck(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(_numberInputElement.Text, out var numberInput))
            {
                if (numberInput == _fibonacciNumbers.first + _fibonacciNumbers.second)
                {
                    _numberInputElement.Background = Brushes.White;
                    (_fibonacciNumbers.first, _fibonacciNumbers.second) = (_fibonacciNumbers.second, numberInput);
                    _numbersSequenceElement.Children.Insert(_numbersSequenceElement.Children.Count - 1, GenerateGrid(_numberInputElement.Text));
                    _points = _numberInputElement.Text.Length;
                    _numberInputElement.Clear();
                }
                else if (_numberInputElement.Background != Brushes.Red)
                {
                    _numberInputElement.Background = Brushes.Red;
                    _heartsCollectionElement.Children.RemoveAt(0);

                    if (_heartsCollectionElement.Children.Count == 0)
                    {
                        GlobalPanel.Children.Clear();

                        var restartButton = new Button { Content = "Restart", Margin = new(10) };
                        restartButton.Click += GenerateInitialState;

                        GlobalPanel.Children.Add(new StackPanel
                        {
                            Orientation = Orientation.Vertical,
                            VerticalAlignment = VerticalAlignment.Center,
                            Children =
                            {
                                new TextBlock { Text = $"You scored {_points} Point{(_points == 1 ? "" : "s")}!", Foreground = Brushes.Red },
                                restartButton
                            }
                        });
                    }
                }
            }
        }
    }
}