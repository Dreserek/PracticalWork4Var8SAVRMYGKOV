using System;
using System.Windows;
using System.Windows.Controls;

namespace PracticalWork4_Var8
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Calculate1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка заполненности
                if (string.IsNullOrWhiteSpace(txtX1.Text) ||
                    string.IsNullOrWhiteSpace(txtY1.Text) ||
                    string.IsNullOrWhiteSpace(txtZ1.Text))
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!double.TryParse(txtX1.Text, out double x) ||
                    !double.TryParse(txtY1.Text, out double y) ||
                    !double.TryParse(txtZ1.Text, out double z))
                {
                    MessageBox.Show("Введите корректные числа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Проверка y > 0 для логарифма
                if (y <= 0)
                {
                    MessageBox.Show("y должен быть положительным для вычисления ln(y).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Проверка знаменателя
                double denominator = Math.Atan(x) + Math.Atan(z);
                if (Math.Abs(denominator) < 1e-9)
                {
                    MessageBox.Show("Знаменатель (arctg(x)+arctg(z)) не может быть равен нулю.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double absXY = Math.Abs(x - y);
                double term1 = Math.Exp(absXY) * Math.Pow(absXY, x + y) / denominator;
                double term2 = Math.Pow(x * x + Math.Pow(Math.Log(y), 2), 1.0 / 3.0); // кубический корень
                double result = term1 + term2;

                txtResult1.Text = result.ToString("F6");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка вычисления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear1_Click(object sender, RoutedEventArgs e)
        {
            txtX1.Clear();
            txtY1.Clear();
            txtZ1.Clear();
            txtResult1.Clear();
        }
    }
}