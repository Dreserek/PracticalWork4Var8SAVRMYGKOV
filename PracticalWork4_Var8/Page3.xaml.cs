using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace PracticalWork4_Var8
{
    public partial class Page3 : Page
    {
        // Коллекция точек для графика
        public ChartValues<LiveCharts.Defaults.ObservablePoint> Points { get; set; }

        public Page3()
        {
            InitializeComponent();
            Points = new ChartValues<LiveCharts.Defaults.ObservablePoint>();
            // Привязка данных к графику
            ChartFunction.DataContext = this;
        }

        private void Calculate3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка заполненности
                if (string.IsNullOrWhiteSpace(txtX0.Text) ||
                    string.IsNullOrWhiteSpace(txtXk.Text) ||
                    string.IsNullOrWhiteSpace(txtDx.Text))
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!double.TryParse(txtX0.Text, out double x0) ||
                    !double.TryParse(txtXk.Text, out double xk) ||
                    !double.TryParse(txtDx.Text, out double dx))
                {
                    MessageBox.Show("Введите корректные числа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (dx <= 0)
                {
                    MessageBox.Show("Шаг dx должен быть положительным.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (x0 > xk)
                {
                    MessageBox.Show("x0 должен быть меньше или равен xk.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Табуляция
                Points.Clear();
                string output = "x\t\ty\n------------------------\n";

                for (double x = x0; x <= xk + 1e-9; x += dx)
                {
                    double y = 9 * Math.Pow(x, 4) + Math.Sin(57.2 + x);
                    Points.Add(new LiveCharts.Defaults.ObservablePoint(x, y));
                    output += $"{x:F4}\t\t{y:F6}\n";
                }

                txtResult3.Text = output;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear3_Click(object sender, RoutedEventArgs e)
        {
            txtX0.Clear();
            txtXk.Clear();
            txtDx.Clear();
            txtResult3.Clear();
            Points.Clear();
        }
    }
}