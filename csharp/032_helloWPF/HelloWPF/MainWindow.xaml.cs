using System.Windows;

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _firstNumber { get; set;  }
        private int _secondNumber { get; set; }
        private char _operator { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = "0";

            _firstNumber = Random.Shared.Next(0, 100);
            _secondNumber = Random.Shared.Next(0, 100);
            _operator = Random.Shared.Next(0, 3) switch
            {
                0 => '+',
                1 => '-',
                2 => '*',
                _ => throw new InvalidOperationException("invalid operator")
            };

            FirstNumber.Text = _firstNumber.ToString();
            SecondNumber.Text = _secondNumber.ToString();
            Operator.Text = _operator.ToString();
        }

        private void OnCheck(object sender, RoutedEventArgs e)
        {
            var input = ResultTextBox.Text;

            if (!int.TryParse(input, out int inputNumber))
            {
                MessageBox.Show("please enter a valid number");
            }
            else
            {
                int? result = _operator switch
                {
                    '+' => _firstNumber + _secondNumber,
                    '-' => _firstNumber - _secondNumber,
                    '*' => _firstNumber * _secondNumber,
                    _ => null
                };

                var correct = result == inputNumber;

                MessageBox.Show($"you guessed the {(correct ? "correct" : "wrong")} number");
                if (correct) { OnLoaded(sender, e); }
            }
        }
    }
}