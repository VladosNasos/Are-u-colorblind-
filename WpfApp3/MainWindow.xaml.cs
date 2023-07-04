using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        private ColorViewModel colorViewModel;

        public MainWindow()
        {
            InitializeComponent();

            // Создание экземпляра модели
            colorViewModel = new ColorViewModel();

            // Привязка свойств модели к элементам управления
            DataContext = colorViewModel;

            // Инициализация значения цветового предварительного просмотра
            UpdateColorPreview();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // При изменении значения слайдеров обновляем цветовой предварительный просмотр
            UpdateColorPreview();
        }

        private void UpdateColorPreview()
        {
            // Обновление цветового предварительного просмотра
            Color color = Color.FromArgb(colorViewModel.Alpha, colorViewModel.Red, colorViewModel.Green, colorViewModel.Blue);
            colorPreview.Background = new SolidColorBrush(color);
        }
    }

    public class ColorViewModel : INotifyPropertyChanged
    {
        private byte alpha;
        private byte red;
        private byte green;
        private byte blue;

        public byte Alpha
        {
            get { return alpha; }
            set
            {
                if (alpha != value)
                {
                    alpha = value;
                    OnPropertyChanged("Alpha");
                }
            }
        }

        public byte Red
        {
            get { return red; }
            set
            {
                if (red != value)
                {
                    red = value;
                    OnPropertyChanged("Red");
                }
            }
        }

        public byte Green
        {
            get { return green; }
            set
            {
                if (green != value)
                {
                    green = value;
                    OnPropertyChanged("Green");
                }
            }
        }

        public byte Blue
        {
            get { return blue; }
            set
            {
                if (blue != value)
                {
                    blue = value;
                    OnPropertyChanged("Blue");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
