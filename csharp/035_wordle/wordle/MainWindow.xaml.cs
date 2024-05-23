using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
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
            var found = new Dictionary<char, SolidColorBrush>();

            var guess = guessed.Select((c, index) => (c, index, evaluated: false)).ToArray();
            var toGuess = _toGuess.Select((c, index) => (c, index, evaluated: false)).ToArray();

            for (var i = 0; i < guess.Length; i++)
            {
                if (guess[i].c == toGuess[i].c)
                {
                    guess[i].evaluated = toGuess[i].evaluated = true;
                    SetColorOnBoard(row, i, Brushes.Green);
                    found.Add(guess[i].c, Brushes.Green);
                }
            }

            for (var i = 0; i < guess.Length; i++)
            {
                if (!guess[i].evaluated)
                {
                    var foundItem = toGuess.FirstOrDefault(item => !item.evaluated && item.c == guess[i].c);

                    if (foundItem.c != default(char))
                    {
                        toGuess[foundItem.index].evaluated = guess[i].evaluated = true;
                        SetColorOnBoard(row, i, Brushes.Yellow);
                        if (!found.ContainsKey(guess[i].c)) { found.Add(guess[i].c, Brushes.Yellow); }
                    }
                }
            }

            for (var i = 0; i < guess.Length; i++)
            {
                if (!guess[i].evaluated)
                {
                    SetColorOnBoard(row, i, Brushes.Gray);
                    if (!found.ContainsKey(guess[i].c)) { found.Add(guess[i].c, Brushes.Gray); }
                }
            }

            for (var i = 0; i < Keyboard.Children.Count; i++)
            {
                for (var j = 0; j < ((StackPanel)Keyboard.Children[i]).Children.Count; j++)
                {
                    var button = (Button)((StackPanel)Keyboard.Children[i]).Children[j];
                    var content = button.Content.ToString();

                    if (content?.Length == 1 && found.TryGetValue(content[0], out var color))
                    {
                        SetColorOnKeyboard(i, j, color);
                    }
                }
            }

            return guessed == _toGuess;
        }
    }
}