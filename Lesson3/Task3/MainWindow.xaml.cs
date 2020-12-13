using System;
using System.IO;
using System.Windows;


namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EventHandler _search;
        private EventHandler _show;
        private EventHandler _compress;

        public MainWindow()
        {
            InitializeComponent();
            DrivesList_Initialized();
            new Presenter(this);
        }

        public event EventHandler Search
        {
            add
            {
                _search += value;
            }
            remove
            {
                _search -= value;
            }
        }
        public event EventHandler ShowContent
        {
            add
            {
                _show += value;
            }
            remove
            {
                _show -= value;
            }
        }
        public event EventHandler Compress
        {
            add
            {
                _compress += value;
            }
            remove
            {
                _compress -= value;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            _search.Invoke(sender, e);
        }

        private void ShowContentButton_Click(object sender, RoutedEventArgs e)
        {
            _show.Invoke(sender, e);
        }

        private void CompressButton_Click(object sender, RoutedEventArgs e)
        {
            _compress.Invoke(sender, e);
        }

        private void DrivesList_Initialized()
        {
            var drives = DriveInfo.GetDrives();

            foreach (var item in drives)
            {
                if (item.DriveType != DriveType.CDRom)
                {
                    drivesList.Items.Add(item.Name);
                }
            }
        }
    }
}
