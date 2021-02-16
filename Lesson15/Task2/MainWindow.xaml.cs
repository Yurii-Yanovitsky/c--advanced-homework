using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task(ConnectDB);
            task.Start();
            await task;
            TextInfo.Text = "Подключен к БД";
            GetData(true);
        }

        private async void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task(DisconnectDB);
            task.Start();
            await task;
            GetData(false);
            TextInfo.Text = "Отключен от БД";
        }

        private void ConnectDB()
        {
            Thread.Sleep(4000);
        }

        private void DisconnectDB()
        {
            Thread.Sleep(4000);
        }

        private void GetData(bool isData)
        {
            if (isData)
            {
                timer.Tick += (sender, e) => TextInfo.Text += "\nДанные получены";
                timer.Interval = new TimeSpan(0, 0, 0, 0, 2000);
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }
    }
}
