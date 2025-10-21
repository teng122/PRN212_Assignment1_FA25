using BusinessObject;
using Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp.Helpers;

namespace WPFApp.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        private readonly CustomerService _service = new CustomerService();

        public ObservableCollection<Customer> Customers { get; set; }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set { _selectedCustomer = value; OnPropertyChanged(); }
        }

        private string _searchKeyword;
        public string SearchKeyword
        {
            get => _searchKeyword;
            set { _searchKeyword = value; OnPropertyChanged(); SearchCustomers(); }
        }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SortAscCommand { get; }
        public ICommand SortDescCommand { get; }

        public CustomerViewModel()
        {
            Customers = new ObservableCollection<Customer>(_service.GetAllCustomers());

            AddCommand = new RelayCommand(_ => AddCustomer());
            UpdateCommand = new RelayCommand(_ => UpdateCustomer(), _ => SelectedCustomer != null);
            DeleteCommand = new RelayCommand(_ => DeleteCustomer(), _ => SelectedCustomer != null);
            SortAscCommand = new RelayCommand(_ => SortCustomers(true));
            SortDescCommand = new RelayCommand(_ => SortCustomers(false));
        }

        private void RefreshData()
        {
            Customers.Clear();
            foreach (var c in _service.GetAllCustomers())
                Customers.Add(c);
        }

        private void AddCustomer()
        {
            try
            {
                var newC = new Customer
                {
                    CustomerFullName = "Tên mới",
                    Telephone = "0123456789",
                    EmailAddress = "new@gmail.com",
                    CustomerBirthday = DateTime.Now.AddYears(-20),
                    Password = "123",
                    CustomerStatus = 1
                };
                _service.AddCustomer(newC);
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateCustomer()
        {
            if (SelectedCustomer == null) return;
            try
            {
                _service.UpdateCustomer(SelectedCustomer);
                MessageBox.Show("Cập nhật thành công!");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteCustomer()
        {
            if (SelectedCustomer == null) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _service.DeleteCustomer(SelectedCustomer.CustomerID);
                RefreshData();
            }
        }

        private void SearchCustomers()
        {
            Customers.Clear();
            foreach (var c in _service.SearchCustomers(SearchKeyword))
                Customers.Add(c);
        }

        private void SortCustomers(bool asc)
        {
            Customers.Clear();
            foreach (var c in _service.SortCustomersByName(asc))
                Customers.Add(c);
        }
    }
}
