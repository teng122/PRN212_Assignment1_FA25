// File: Views/CustomerMainWindow.xaml.cs
using System.Windows;
using BusinessObject;
using Services;

namespace HotelManager.Views
{
    public partial class CustomerMainWindow : Window
    {
        private readonly ICustomerService _customerService;
        private Customer _currentCustomer;

        public CustomerMainWindow(Customer customer)
        {
            InitializeComponent();
            _customerService = new CustomerService();
            _currentCustomer = customer;
            LoadCustomerProfile();
        }

        private void LoadCustomerProfile()
        {
            txtWelcome.Text = $"Welcome, {_currentCustomer.CustomerFullName}!";
            txtFullName.Text = _currentCustomer.CustomerFullName;
            txtTelephone.Text = _currentCustomer.Telephone;
            txtEmail.Text = _currentCustomer.EmailAddress;
            dpBirthday.SelectedDate = _currentCustomer.CustomerBirthday;
            txtPassword.Password = _currentCustomer.Password;
        }

        private void btnUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MessageBox.Show("Full name is required.", "Validation Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTelephone.Text))
                {
                    MessageBox.Show("Telephone is required.", "Validation Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    MessageBox.Show("Password is required.", "Validation Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                _currentCustomer.CustomerFullName = txtFullName.Text.Trim();
                _currentCustomer.Telephone = txtTelephone.Text.Trim();
                _currentCustomer.CustomerBirthday = dpBirthday.SelectedDate;
                _currentCustomer.Password = txtPassword.Password;

                _customerService.UpdateCustomer(_currentCustomer);

                MessageBox.Show("Profile updated successfully!", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                txtWelcome.Text = $"Welcome, {_currentCustomer.CustomerFullName}!";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}