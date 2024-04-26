using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cells Cells { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < 3; i++)
            {
                RowCombo.Items.Add(i + 1);
                ColumnCombo.Items.Add(i + 1);

                var rowPanel = new StackPanel();
                for (var j = 0; j < 3; j++) { rowPanel.Children.Add(new Border { Child = new TextBlock() }); }
                Field.Children.Add(rowPanel);
            }

            Cells = new(Field.Children.OfType<StackPanel>().SelectMany(rowPanel => rowPanel.Children.OfType<Border>()));
            RowCombo.SelectedItem = ColumnCombo.SelectedItem = 1;
        }

        private void OnSet(object sender, RoutedEventArgs e)
        {
            if (!Cells.TrySetPlayer(RowCombo.SelectedIndex, ColumnCombo.SelectedIndex, out var errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
            else if (Cells.TryGetWinner(out var player))
            {
                MessageBox.Show($"player {player} wins");
                Close();
            }
        }
    }

    public class Cells(IEnumerable<Border> cells)
    {
        private bool _playerXTurn = false;
        private IEnumerable<Border> _cells { get; set; } = cells;

        public Border GetBorder(int row, int col) => _cells.ElementAt(row * 3 + col);
        public TextBlock GetTextBlock(int row, int col) => (TextBlock)(GetBorder(row, col).Child);
        public (Border border, TextBlock textBlock) GetBorderAndTextBlock(int row, int col) => (GetBorder(row, col), GetTextBlock(row, col));
        public bool IsSet(int row, int col) => !string.IsNullOrEmpty(GetTextBlock(row, col).Text);

        public bool TrySetPlayer(int row, int col, out string? errorMessage)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                errorMessage = "invalid row or column";
                return false;
            }
            else if (IsSet(row, col))
            {
                errorMessage = "field already used";
                return false;
            }
            else
            {
                errorMessage = null;
                GetTextBlock(row, col).Text = (_playerXTurn = !_playerXTurn) ? "X" : "O";
                return true;
            }
        }

        public bool TryGetWinner(out string? player)
        {
            List<List<(Border border, TextBlock textBlock)>> winningFields = [];

            for (var i = 0; i < 3; i++)
            {
                var rowFields = new List<(Border, TextBlock)>();
                var colFields = new List<(Border, TextBlock)>();

                for (var j = 0; j < 3; j++)
                {
                    rowFields.Add(GetBorderAndTextBlock(i, j));
                    colFields.Add(GetBorderAndTextBlock(j, i));
                }

                winningFields.Add(rowFields);
                winningFields.Add(colFields);
            }

            winningFields.Add([
                GetBorderAndTextBlock(0, 0),
                GetBorderAndTextBlock(1, 1),
                GetBorderAndTextBlock(2, 2)
            ]);

            winningFields.Add([
                GetBorderAndTextBlock(0, 2),
                GetBorderAndTextBlock(1, 1),
                GetBorderAndTextBlock(2, 0)
            ]);

            foreach (var winningField in winningFields)
            {
                if (
                    winningField.DistinctBy(field => field.textBlock.Text).Count() == 1
                    && winningField.All(field => !string.IsNullOrEmpty(field.textBlock.Text))
                )
                {
                    foreach (var (border, _) in winningField) { border.Background = Brushes.Red; }
                    player = winningField[0].textBlock.Text;
                    return true;
                }
            }

            player = null;
            return false;
        }
    }
}