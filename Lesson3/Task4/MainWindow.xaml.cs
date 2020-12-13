using System;
using System.Windows;
using System.Windows.Media;

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EventHandler _windowLoad;
        private EventHandler _saveColor;
        private EventHandler _selectColor;

        public MainWindow()
        {
            InitializeComponent();
            new Presenter(this);
        }

        public event EventHandler WindowLoad
        {
            add
            {
                _windowLoad += value;
            }
            remove
            {
                _windowLoad -= value;
            }
        }
        public event EventHandler SelectColor
        {
            add
            {
                _selectColor += value;
            }
            remove
            {
                _selectColor -= value;
            }
        }
        public event EventHandler SaveColor
        {
            add
            {
                _saveColor += value;
            }
            remove
            {
                _saveColor -= value;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _windowLoad.Invoke(sender, e);
        }

        private void SaveColor_Click(object sender, RoutedEventArgs e)
        {
            _saveColor.Invoke(sender, e);
        }

        private void SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            _selectColor.Invoke(sender, e);
        }
    }
}
