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
        if (string.IsNullOrWhiteSpace(InputTextBox.Text) || !double.TryParse(InputTextBox.Text, out double x))
        {
            MessageBox.Show("Пожалуйста, введите корректное значение для x.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        double result = 0;

        if (RadioButtonSh.IsChecked == true)
        {
            result = Math.Sinh(x);
        }
        else if (RadioButtonX2.IsChecked == true)
        {
            result = Math.Pow(x, 2);
        }
        else if (RadioButtonEx.IsChecked == true)
        {
            result = Math.Exp(x);
        }
        else
        {
            MessageBox.Show("Пожалуйста, выберите функцию.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        ResultTextBox.Text = result.ToString();
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        InputTextBox.Clear();
        ResultTextBox.Clear();
        RadioButtonSh.IsChecked = false;
        RadioButtonX2.IsChecked = false;
        RadioButtonEx.IsChecked = false;
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
            Application.Current.Shutdown();
        }
    }
}
}