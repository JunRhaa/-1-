using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практическая_работа_1_Писецкий_Полторабатько
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputXTextBox.Text) || string.IsNullOrEmpty(InputBTextBox.Text))
            {
                MessageBox.Show("Введите значения x и b!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(InputXTextBox.Text, out double x) || !double.TryParse(InputBTextBox.Text, out double b))
            {
                MessageBox.Show("Неверный формат чисел!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double f_x = 0;

            if (RadioFunction1.IsChecked == true)
            {
                f_x = Math.Sinh(x); // f(x) = sh(x)
            }
            else if (RadioFunction2.IsChecked == true)
            {
                f_x = Math.Pow(x, 2); // f(x) = x^2
            }
            else if (RadioFunction3.IsChecked == true)
            {
                f_x = Math.Exp(x); // f(x) = e^x
            }

            double product = x * b;

            double result;

            if (product > 0.5 && product < 10)
            {
                double numerator = Math.Exp(f_x) - Math.Abs(b);
                double denominator = Math.Sqrt(Math.Abs(f_x + b));

                if (denominator == 0)
                {
                    MessageBox.Show("Деление на ноль невозможно! Измените значения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                result = numerator / denominator;
            }
            else if (product > 0.1 && product < 0.5)
            {
                result = Math.Sqrt(Math.Abs(f_x + b));
            }
            else
            {
                result = 2 * Math.Pow(f_x, 2);
            }

            ResultTextBox.Text = result.ToString("F4"); // Вывод результата с 4 знаками после запятой
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputXTextBox.Clear();
            InputBTextBox.Clear();
            ResultTextBox.Clear();
            RadioFunction1.IsChecked = true; // Сброс выбора функции на f(x) = sh(x)
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}