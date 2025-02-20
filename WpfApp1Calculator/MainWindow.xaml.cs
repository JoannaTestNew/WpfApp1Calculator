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

namespace WpfApp1Calculator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string _currentInput = string.Empty;
    private string _operator = string.Empty;
    private double _firstNumber = 0;
    private double _secondNumber = 0;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as System.Windows.Controls.Button;
        if (button != null)
        {
            _currentInput += button.Content.ToString();
            ResultTextBox.Text = _currentInput;
        }
    }

    private void Operator_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as System.Windows.Controls.Button;
        if (button != null && button.Content != null)
        {
            _firstNumber = double.Parse(_currentInput);
            _operator = button.Content.ToString() ?? string.Empty;
            _currentInput = string.Empty;
        }
    }

    private void Equals_Click(object sender, RoutedEventArgs e)
    {
        _secondNumber = double.Parse(_currentInput);
        double result = 0;

        switch (_operator)
        {
            case "+":
                result = _firstNumber + _secondNumber;
                break;
            case "-":
                result = _firstNumber - _secondNumber;
                break;
            case "*":
                result = _firstNumber * _secondNumber;
                break;
            case "/":
                result = _firstNumber / _secondNumber;
                break;
        }

        ResultTextBox.Text = result.ToString();
        _currentInput = result.ToString();
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        _currentInput = string.Empty;
        _operator = string.Empty;
        _firstNumber = 0;
        _secondNumber = 0;
        ResultTextBox.Text = string.Empty;
    }
}
