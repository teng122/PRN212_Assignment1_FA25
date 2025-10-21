using System.IO;
using System.Linq;
using System.Windows;
using BusinessObject;
using DataAccessLayer;
using Microsoft.Extensions.Configuration;

namespace WPFApp
{
    public partial class LoginWindow : Window
    {
        private readonly string adminEmail;
        private readonly string adminPassword;

        public LoginWindow()
        {
            InitializeComponent();

            // Đọc file cấu hình
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            adminEmail = config["AdminAccount:Email"];
            adminPassword = config["AdminAccount:Password"];
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Password.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Kiểm tra admin
            if (email.Equals(adminEmail) && password.Equals(adminPassword))
            {
                MessageBox.Show("Đăng nhập Admin thành công!");
                new MainWindow().Show();
                this.Close();
                return;
            }

            // Kiểm tra Customer trong DAO
            var customer = CustomerDAO.GetCustomers()
                .FirstOrDefault(c => c.EmailAddress == email && c.Password == password);

            if (customer != null)
            {
                MessageBox.Show($"Xin chào {customer.CustomerFullName}!");
                new Views.CustomerManagementWindow().Show();
                this.Close();
                return;
            }

            MessageBox.Show("Sai email hoặc mật khẩu!");
        }
    }
}
