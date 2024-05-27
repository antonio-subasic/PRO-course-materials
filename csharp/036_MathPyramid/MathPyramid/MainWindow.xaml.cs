using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MathPyramid
{
    [Flags]
    public enum MarkType
    {
        None = 0b0000,
        OnlyFilled = 0b0001,
        Correct = 0b0010,
        Incorrect = 0b0100,
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<List<int>> _solvedPyramid = [[]];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnGenerate(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(BaseWidth.Text, out var baseWidth) || baseWidth is < 2 or > 10) { MessageBox.Show("width of base must be number between 2 and 10"); }
            else if (!int.TryParse(BaseDigits.Text, out var baseDigits) || baseDigits is < 1 or > 3) { MessageBox.Show("number of digits in base must be number between 1 and 3"); }
            else
            {
                if (Pyramid.Children.Count > 0)
                {
                    Pyramid.Children.Clear();
                    _solvedPyramid = [[]];
                }

                Pyramid.Background = Brushes.White;

                List<List<char>> operations = [];

                for (var i = 1; i <= baseWidth; i++)
                {
                    if (i < baseWidth) { operations.Add([]); }
                    var numberRow = new StackPanel { Orientation = Orientation.Horizontal };
                    var operationRow = new StackPanel { Orientation = Orientation.Horizontal };

                    for (var j = 1; j <= i; j++)
                    {
                        int? value = i == baseWidth ? Random.Shared.Next((int)Math.Pow(10, baseDigits)) : null;
                        if (value.HasValue) { _solvedPyramid[0].Add(value.Value); }
                        numberRow.Children.Add(new TextBox
                        {
                            Text = value.ToString(),
                            Padding = new(5),
                            MinWidth = 40,
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            TextAlignment = TextAlignment.Center,
                            IsReadOnly = i == baseWidth,
                        });

                        var operation = Random.Shared.Next(2) == 0 ? '+' : '-';
                        if (i < baseWidth) { operations[i - 1].Add(operation); }
                        operationRow.Children.Add(new TextBlock
                        {
                            Text = operation.ToString(),
                            Margin = new Thickness(5, 0, 5, 0),
                            FontWeight = FontWeights.Bold,
                            MinWidth = 40,
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            TextAlignment = TextAlignment.Center,
                        });
                    }

                    Pyramid.Children.Add(numberRow);
                    if (i < baseWidth) { Pyramid.Children.Add(operationRow); }
                }

                for (var i = 1; i < baseWidth; i++)
                {
                    _solvedPyramid.Add([]);

                    for (var j = 0; j < _solvedPyramid[^2].Count - 1; j++)
                    {
                        var first = _solvedPyramid[i - 1][j];
                        var second = _solvedPyramid[i - 1][j + 1];
                        _solvedPyramid[^1].Add(operations[^i][j] == '+' ? first + second : first - second);
                    }
                }
            }
        }

        private IEnumerable<T> GetPyramidChildrenOfType<T>(Index index) => ((StackPanel)Pyramid.Children[index]).Children.OfType<T>();
        private IEnumerable<TextBox> GetValueBoxes(int nth) => GetPyramidChildrenOfType<TextBox>(^(nth * 2 + 1));
        private IEnumerable<IEnumerable<TextBox>> GetAllValueBoxes() => Enumerable.Range(0, (int)Math.Ceiling(Pyramid.Children.Count / 2.0)).Select(GetValueBoxes);
        private bool AllValueBoxesValid() => Pyramid.Children.OfType<StackPanel>().SelectMany(stackPanel => stackPanel.Children.OfType<TextBox>()).All(textBox => textBox.Text.Length == 0 || int.TryParse(textBox.Text, out _));

        private bool EvaluatePyramid(MarkType markType = MarkType.Correct | MarkType.Incorrect, bool reveal = false)
        {
            if (!AllValueBoxesValid())
            {
                MessageBox.Show("all cells must contain valid numbers");
                return false;
            }
            else
            {
                var solved = true;

                for (var i = 1; i < Pyramid.Children.Count / 2.0; i++)
                {
                    var currentChildren = GetValueBoxes(i);

                    for (var j = 0; j < currentChildren.Count(); j++)
                    {
                        var result = _solvedPyramid[i][j];
                        var currentChild = currentChildren.ElementAt(j);
                        int? currentChildValue = reveal ? result : (int.TryParse(currentChild.Text, out var value) ? value : null);

                        if (reveal)
                        {
                            currentChild.Text = result.ToString();
                            currentChild.Background = Brushes.White;
                        }

                        if ((markType & MarkType.OnlyFilled) == 0 || (markType & MarkType.OnlyFilled) == MarkType.OnlyFilled && currentChildValue.HasValue)
                        {
                            if ((markType & MarkType.Correct) == MarkType.Correct && currentChildValue == result) { currentChild.Background = Brushes.White; }
                            else if ((markType & MarkType.Incorrect) == MarkType.Incorrect && currentChildValue != result) { currentChild.Background = Brushes.Red; }

                            solved &= currentChildValue == result;
                        }
                    }
                }

                return solved;
            }
        }

        void OnPyramidClickEvent(object sender, RoutedEventArgs e)
        {
            if (_solvedPyramid[0].Count > 0)
            {
                switch (((Button)sender).Content.ToString()?.ToLower())
                {
                    case "check":
                        if (EvaluatePyramid()) { Pyramid.Background = Brushes.LightGreen; }
                        break;

                    case "solve":
                        EvaluatePyramid(reveal: true);
                        Pyramid.Background = Brushes.LightGreen;
                        break;

                    case "verify":
                        MessageBox.Show($"{(EvaluatePyramid(markType: MarkType.None) ? "" : "in")}correct solution");
                        break;

                    case "hint":
                        if (EvaluatePyramid(markType: MarkType.OnlyFilled | MarkType.Incorrect | MarkType.Correct))
                        {
                            var rowWithEmptyCells = GetAllValueBoxes().Select((boxes, index) => (boxes, index)).FirstOrDefault(item => item.boxes.Any(box => box.Text.Length == 0));

                            if (rowWithEmptyCells.boxes?.Count() > 0)
                            {
                                var emptyCells = rowWithEmptyCells.boxes.Select((box, index) => (box, index)).Where(item => item.box.Text.Length == 0);
                                var emptyCell = emptyCells.ElementAt(Random.Shared.Next(emptyCells.Count()));

                                emptyCell.box.Text = _solvedPyramid[rowWithEmptyCells.index][emptyCell.index].ToString();
                                emptyCell.box.Background = Brushes.White;
                            }
                        }
                        break;
                }
            }
        }
    }
}