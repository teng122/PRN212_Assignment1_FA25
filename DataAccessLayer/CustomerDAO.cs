using BusinessObject;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        private static List<Customer> customers = new List<Customer>();

        // Khởi tạo dữ liệu mẫu
        static CustomerDAO()
        {
            customers = new List<Customer>
            {
                new Customer { CustomerID = 1, CustomerFullName = "Nguyen Van A", Telephone = "0123456789", EmailAddress = "a@gmail.com", CustomerBirthday = new DateTime(1999, 5, 12), CustomerStatus = 1, Password = "123" },
                new Customer { CustomerID = 2, CustomerFullName = "Tran Thi B", Telephone = "0987654321", EmailAddress = "b@gmail.com", CustomerBirthday = new DateTime(2000, 10, 2), CustomerStatus = 1, Password = "123" }
            };
        }

        public static List<Customer> GetCustomers() => customers;

        public static Customer? GetCustomerById(int id)
            => customers.FirstOrDefault(c => c.CustomerID == id);

        public static void SaveCustomer(Customer c)
        {
            int nextId = customers.Any() ? customers.Max(x => x.CustomerID) + 1 : 1;
            c.CustomerID = nextId;
            customers.Add(c);
        }

        public static void UpdateCustomer(Customer c)
        {
            var existing = GetCustomerById(c.CustomerID);
            if (existing != null)
            {
                existing.CustomerFullName = c.CustomerFullName;
                existing.Telephone = c.Telephone;
                existing.EmailAddress = c.EmailAddress;
                existing.CustomerBirthday = c.CustomerBirthday;
                existing.Password = c.Password;
                existing.CustomerStatus = c.CustomerStatus;
            }
        }

        public static void DeleteCustomer(int id)
        {
            var existing = GetCustomerById(id);
            if (existing != null)
            {
                // Xóa mềm
                existing.CustomerStatus = 2;
            }
        }
    }
}
