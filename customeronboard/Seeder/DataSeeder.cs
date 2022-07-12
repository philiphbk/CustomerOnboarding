using System.Collections.Generic;
using System.Linq;
using customeronboard.Data;
using customeronboard.Models;

namespace customeronboard.Seeder
{
    public class DataSeeder
    {
        private readonly CustomerDbContext _customerDb;

        public DataSeeder(CustomerDbContext customerDb)
        {
            this._customerDb = customerDb;
        }

        public void Seed()
        {
            if (!_customerDb.Customers.Any())
            {
                var customer = new List<Customer>()
                {
                    new Customer()
                    {
                        Id = "1",
                        Name = "James Arthur",
                        PhoneNumber = "+234-706-787-4589",
                        Email = "sample@gmail.com",
                        Password = "james",
                        Residence = "Lagos",
                        LGA = "Ojodu"
                    },
                    new Customer()
                    {
                        Id = "2",
                        Name = "Tosin Nifemi",
                        PhoneNumber = "+234-706-756-4589",
                        Email = "sample2@gmail.com",
                        Password = "tosin",
                        Residence = "Lagos",
                        LGA = "Ojodu"
                    }
                };

                _customerDb.Customers.AddRange(customer);
                _customerDb.SaveChanges();
            }


        }
    }
}
