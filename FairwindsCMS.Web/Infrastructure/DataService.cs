using FairwindsCMS.Domain.Models;
using FairwindsCMS.Web.Abstractions;
using FairwindsCMS.Web.Models;

namespace FairwindsCMS.Web.Infrastructure
{
    public class DataService : IDataService
    {
        public List<Customer> CleanSSN(List<Customer> customers)
        {
            customers.ForEach(customer =>
            {
                customer.Ssn = customer.Ssn?.GetLastFour();
            });
            return customers;
        }

        public List<Customer> CalculateAge(List<Customer> customers)
        {
            customers.ForEach(customer =>
            {
                customer.Age = customer.DateBirth.CalculateAge();
            });
            return customers;
        }

        public async Task<CustomerFormVm> GetCustomerFormVm()
        {
            CustomerFormVm customerFormVm = new CustomerFormVm();
            Random random = new Random(DateTime.Now.Millisecond);
            var randCustomerNumber = random.Next(10000, 99999);
            Customer customer = new() { CustomerNumber = randCustomerNumber };
            customerFormVm.Customer = customer;
            return customerFormVm;
        }
    }
}
