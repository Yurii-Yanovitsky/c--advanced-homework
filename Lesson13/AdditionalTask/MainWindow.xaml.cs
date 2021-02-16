using System;
using System.Windows;

namespace AdditionalTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EventHandler _isCompleted;
        private EventHandler _callBack;
        private EventHandler _end;
        public MainWindow()
        {
            InitializeComponent();
            new Presenter(this);
        }

        public event EventHandler IsCompletdClick
        {
            add
            {
                _isCompleted += value;
            }
            remove
            {
                _isCompleted -= value;
            }
        }

        public event EventHandler CallBackCLick
        {
            add
            {
                _callBack += value;
            }
            remove
            {
                _callBack -= value;
            }
        }

        public event EventHandler EndClick
        {
            add
            {
                _end += value;
            }
            remove
            {
                _end -= value;
            }
        }

        private void IsCompleted_Click(object sender, RoutedEventArgs e)
        {
            _isCompleted.Invoke(sender, e);
        }

        private void CallBack_Click(object sender, RoutedEventArgs e)
        {
            _callBack.Invoke(sender, e);
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            _end.Invoke(sender, e);
        }
    }
}
