using System.Windows;
using WPFApp.Views;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenCustomer_Click(object sender, RoutedEventArgs e)
        {
            new CustomerManagementWindow().ShowDialog();
        }

        private void OpenRoom_Click(object sender, RoutedEventArgs e)
        {
            new RoomManagementWindow().ShowDialog();
        }

        private void OpenRoomType_Click(object sender, RoutedEventArgs e)
        {
            new RoomTypeManagementWindow().ShowDialog();
        }
    }
}
