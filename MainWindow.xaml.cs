using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private bool showingSum = true; // Переменная для переключения между суммой и произведением

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(one.Text);
                int b = Convert.ToInt32(two.Text);
                int c = Convert.ToInt32(three.Text);
                int sum = a + b + c;
                int product = a * b * c;

                // Переключение 
                if (showingSum)
                {
                    result.Text = "Сумма трех чисел: " + sum;
                }
                else
                {
                    result.Text = "Произведение трех чисел: " + product;
                }

                showingSum = !showingSum; // Меняем 
            }
            catch (FormatException)
            {
                result.Text = "Пожалуйста, введите корректные числа.";
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                double sideLength = Convert.ToDouble(one_Copy.Text);
                double P = 4 * sideLength;
                double S = sideLength * sideLength;

                result_Copy.Text = $"Периметр: {P:F2}\nПлощадь: {S:F2}"; // до двух знаков 
            }
            catch (FormatException)
            {
                result_Copy.Text = "Пожалуйста, введите корректное число для стороны.";
            }
        }
        private void OpenImage_Click(object sender, RoutedEventArgs e)
        {
            // Создать и показать диалог открытия файла
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Загрузить изображение и отобразить его
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                imageControl.Source = bitmap;
            }
        }
    }
}
