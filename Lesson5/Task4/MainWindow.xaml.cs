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

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EventHandler _backColorChanged;
        private EventHandler _textColorChanged;
        private EventHandler _textSizeChanged;
        private EventHandler _textFontChanged;
        private EventHandler _loaded;
        private EventHandler _saveSettings;

        public MainWindow()
        {
            InitializeComponent();
            TextSizes.ItemsSource = new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20 };
            TextFonts.ItemsSource = Fonts.SystemFontFamilies.OrderBy(x => x.Source);
            new Presenter(this);
        }

        public event EventHandler BackColorChanged
        {

            add
            {
                _backColorChanged += value;
            }
            remove
            {
                _backColorChanged -= value;
            }

        }

        public event EventHandler TextColorChanged
        {
            add
            {
                _textColorChanged += value;
            }
            remove
            {
                _textColorChanged -= value;
            }
        }

        public event EventHandler TextSizeChanged
        {
            add
            {
                _textSizeChanged += value;
            }
            remove
            {
                _textSizeChanged -= value;
            }
        }

        public event EventHandler TextFontChanged
        {
            add
            {
                _textFontChanged += value;
            }
            remove
            {
                _textFontChanged -= value;
            }
        }

        public event EventHandler WindowLoaded
        {
            add
            {
                _loaded += value;
            }
            remove
            {
                _loaded -= value;
            }
        }

        public event EventHandler SaveSettings
        {
            add
            {
                _saveSettings += value;
            }
            remove
            {
                _saveSettings -= value;
            }
        }

        private void ColorPickerBack_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            _backColorChanged.Invoke(sender, e);
        }

        private void ColorPickerText_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            _textColorChanged.Invoke(sender, e);
        }

        private void TextSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _textSizeChanged.Invoke(sender, e);
        }

        private void TextFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _textFontChanged.Invoke(sender, e);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _saveSettings.Invoke(sender, e);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _loaded.Invoke(sender, e);
        }
    }
}
