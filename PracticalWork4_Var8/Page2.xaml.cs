using System;
using System.Windows;
using System.Windows.Controls;

namespace PracticalWork4_Var8
{
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private double GetFx(double x)
        {
            if (rbSh.IsChecked == true)
                return Math.Sinh(x);
            if (rbX2.IsChecked == true)
                return x * x;
            // rbExp
            return Math.Exp(x);
        }

        private void Calculate2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtX2.Text) || string.IsNullOrWhiteSpace(txtM2.Text))
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!double.TryParse(txtX2.Text, out double x) || !double.TryParse(txtM2.Text, out double m))
                {
                    MessageBox.Show("Введите корректные числа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double fx = GetFx(x);
                double absFx = Math.Abs(fx);
                double result;

                // Условия
                if (m > -1 && m < x)
                {
                    result = Math.Sin(5 * fx + 3 * m * absFx);
                }
                else if (x > m)
                {
                    result = Math.Cos(3 * fx + 5 * m * absFx);
                }
                else if (Math.Abs(x - m) < 1e-9) // x == m
                {
                    result = (fx + m) * (fx + m);
                }
                else
                {
                    MessageBox.Show("Не выполнено ни одно из условий (возможно x < m).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                txtResult2.Text = result.ToString("F6");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear2_Click(object sender, RoutedEventArgs e)
        {
            txtX2.Clear();
            txtM2.Clear();
            txtResult2.Clear();
            rbSh.IsChecked = true;
        }
    }
}