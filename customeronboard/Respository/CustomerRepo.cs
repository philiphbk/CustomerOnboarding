using System;
using System.Collections.Generic;
using System.Linq;
using customeronboard.Data;
using customeronboard.Models;

namespace customeronboard.Respository
{
    public class CustomerRepo: ICustomerRepo
    {
        private readonly CustomerDbContext _customers;

        public CustomerRepo(CustomerDbContext customers)
        {
            _customers = customers;
        }

        public void CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _customers.Customers.Add(customer);
            _customers.SaveChanges();
        }


        public void DeleteCustomerByName(string name)
        {
            _customers.RemoveRange(name);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            var value = Convert.ToString(id);
            return _customers.Customers.FirstOrDefault(x => x.Id.Equals(value));
        }

        public Customer GetCustomerByName(string name)
        {
            return _customers.Customers.Find(name);
        }

        public bool SaveChanges()
        {
            return (_customers.SaveChanges() >= 0);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customers.Update(customer);
        }
    }
}
