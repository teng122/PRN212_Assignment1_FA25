using BusinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public List<Customer> GetAllCustomers()
            => _customerRepository.GetCustomers().Where(c => c.CustomerStatus == 1).ToList();

        public void AddCustomer(Customer c)
        {
            if (string.IsNullOrWhiteSpace(c.CustomerFullName))
                throw new Exception("Tên khách hàng không được để trống.");
            if (string.IsNullOrWhiteSpace(c.EmailAddress))
                throw new Exception("Email không được để trống.");
            if (!c.EmailAddress.Contains("@"))
                throw new Exception("Email không hợp lệ.");

            // kiểm tra trùng email
            var existing = _customerRepository.GetCustomers()
                .FirstOrDefault(x => x.EmailAddress.Equals(c.EmailAddress, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
                throw new Exception("Email đã tồn tại.");

            _customerRepository.SaveCustomer(c);
        }

        public void UpdateCustomer(Customer c)
        {
            if (string.IsNullOrWhiteSpace(c.CustomerFullName))
                throw new Exception("Tên khách hàng không được để trống.");
            _customerRepository.UpdateCustomer(c);
        }

        public void DeleteCustomer(int id) => _customerRepository.DeleteCustomer(id);

        // 🔎 Tìm kiếm khách hàng theo tên hoặc email
        public List<Customer> SearchCustomers(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllCustomers();

            return _customerRepository.GetCustomers()
                .Where(c => c.CustomerStatus == 1 &&
                    (c.CustomerFullName.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    || c.EmailAddress.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        // 📊 Sắp xếp theo tên
        public List<Customer> SortCustomersByName(bool ascending = true)
        {
            var data = GetAllCustomers();
            return ascending
                ? data.OrderBy(c => c.CustomerFullName).ToList()
                : data.OrderByDescending(c => c.CustomerFullName).ToList();
        }
    }
}
