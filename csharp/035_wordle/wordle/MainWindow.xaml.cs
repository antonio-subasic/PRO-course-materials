using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace wordle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int ROWS = 6;
        const int COLS = 5;

        const string SEND = "SEND";
        const string BACKSPACE = "BACKSPACE";

        private string[][] _keys = [
            ["Q", "W", "E", "R", "T", "Z", "U", "I", "O", "P"],
            ["A", "S", "D", "F", "G", "H", "J", "K", "L"],
            ["Y", "X", "C", "V", "B", "N", "M"],
            [SEND, "Ü", "Ö", "Ä", "ß", BACKSPACE]
        ];

        private int _row = 0;
        private int _col = 0;

        private string _toGuess;
        private string[] _available = [];

        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, eventArgs) => OnLoaded();
            KeyDown += (sender, eventArgs) => HandleEvent(eventArgs.Key switch
            {
                Key.Enter => SEND,
                Key.Back => BACKSPACE,
                _ => new KeyConverter().ConvertToString(eventArgs.Key)
            });

            var wordsToGuess = File.ReadAllLines("toguess.txt");
            _toGuess = wordsToGuess[Random.Shared.Next(wordsToGuess.Length)].ToUpper();

            _available = [.. File.ReadAllLines("available.txt").Select(word => word.ToUpper())];
        }

        private void OnLoaded()
        {
            LoadBoard();
            LoadKeyboard();
        }

        private void LoadBoard()
        {
            for (var i = 0; i < ROWS; i++)
            {
                var stackPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                stackPanel.SetValue(Grid.RowProperty, i);

                for (var j = 0; j < COLS; j++)
                {
                    stackPanel.Children.Add(new Border
                    {
                        Margin = new(1),
                        BorderThickness = new(1),
                        BorderBrush = Brushes.Black,
                        CornerRadius = new(5),
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Child = new TextBlock
                        {
                            Width = 60,
                            Height = 60,
                            FontSize = 20,
                            TextAlignment = TextAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Padding = new(15)
                        }
                    });
                }

                Board.Children.Add(stackPanel);
            }
        }

        private void LoadKeyboard()
        {
            for (var i = 0; i < 4; i++)
            {
                var stackPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Stretch
                };

                stackPanel.SetValue(Grid.RowProperty, i);

                foreach (var key in _keys[i])
                {
                    var button = new Button
                    {
                        Content = key,
                        Width = 50 + 7.5 * (key.Length - 1),
                        Height = 50,
                        Margin = new(1)
                    };

                    button.Click += OnClick;
                    stackPanel.Children.Add(button);
                }

                Keyboard.Children.Add(stackPanel);
            }
        }

        private void HandleEvent(string? key)
        {
            var stackPanel = (StackPanel)Board.Children[_row];

            switch (key)
            {
                case SEND:
                    {
                        if (_col == COLS)
                        {
                            var guess = string.Join(
                                "",
                                stackPanel.Children.OfType<Border>().Select(border => ((TextBlock)border.Child).Text)
                            );

                            if (!_available.Contains(guess))
                            {
                                MessageBox.Show("invalid word");
                                for (var i = 0; i < COLS; i++) { SetTextOnBoard(_row, i); }
                            }
                            else
                            {
                                var guessed = EvaluateGuess(_row, guess);

                                if (++_row == ROWS || guessed)
                                {
                                    MessageBox.Show($"wordle{(guessed ? "" : " not")} solved!");
                                    Close();
                                }
                            }

                            _col = 0;
                        }

                        break;
                    }

                case BACKSPACE:
                    SetTextOnBoard(_row, _col = Math.Max(0, _col - 1));
                    break;

                default:
                    if (_col != COLS) { SetTextOnBoard(_row, _col++, key); }
                    break;
            }
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            HandleEvent(((Button)sender).Content.ToString());
        }

        private Border GetBorderFromBoard(int row, int col) => (Border)((StackPanel)Board.Children[row]).Children[col];

        private void SetTextOnBoard(int row, int col, string? text = null)
        {
            var border = GetBorderFromBoard(row, col);
            ((TextBlock)border.Child).Text = text ?? "";
        }

        private void SetColorOnBoard(int row, int col, Brush color)
        {
            var border = GetBorderFromBoard(row, col);
            border.Background = color;
        }

        private void SetColorOnKeyboard(int row, int col, Brush color)
        {
            var button = (Button)((StackPanel)Keyboard.Children[row]).Children[col];
            button.Background = color;
        }

        private bool EvaluateGuess(int row, string guessed)
        {
            for (var i = 0; i < guessed.Length; i++)
            {
                var color = guessed[i] == _toGuess[i] ? Brushes.Green : _toGuess.Contains(guessed[i]) ? Brushes.Yellow : Brushes.Gray;

                SetColorOnBoard(row, i, color);

                for (var j = 0; j < Keyboard.Children.Count; j++)
                {
                    for (var k = 0; k < ((StackPanel)Keyboard.Children[j]).Children.Count; k++)
                    {
                        var button = (Button)((StackPanel)Keyboard.Children[j]).Children[k];

                        if (button.Content.ToString() == guessed[i].ToString())
                        {
                            SetColorOnKeyboard(j, k, color);
                            break;
                        }
                    }
                }
            }

            return guessed == _toGuess;
        }
    }
}