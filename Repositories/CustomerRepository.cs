using BusinessObject;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetCustomers() => CustomerDAO.GetCustomers();
        public Customer? GetCustomerById(int id) => CustomerDAO.GetCustomerById(id);
        public void SaveCustomer(Customer customer) => CustomerDAO.SaveCustomer(customer);
        public void UpdateCustomer(Customer customer) => CustomerDAO.UpdateCustomer(customer);
        public void DeleteCustomer(int id) => CustomerDAO.DeleteCustomer(id);
    }
}