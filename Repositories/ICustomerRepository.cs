using BusinessObject;
using System.Collections.Generic;

namespace Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer? GetCustomerById(int id);
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}