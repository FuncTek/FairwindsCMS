using FairwindsCMS.Domain.Abstractions;
using FairwindsCMS.Domain.Models;
using FairwindsCMS.Domain.Clients;
using System.Net.Http;

namespace FairwindsCMS.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public async Task Can_Get_CustomersAsync()
        {
            //Arrange 


            //Act 
            List<Customer> customers = await new CustomerService(new HttpClient()
            {
                BaseAddress = new("https://my.api.mockaroo.com/customers.json?key=e95894a0")
            }).GetAll();

            //Assert    
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Count > 0);
        }

        [TestMethod]
        public async Task Can_Save_CustomersAsync()
        {
            //Arrange 

            Customer customer = new()
            {
                DateBirth = Convert.ToDateTime("02/02/2002"),
                Email = "somecustomer@mymail.com",
                FirstName = "John",
                LastName = "Doe",
                JoinDate = DateTime.Today,
                MobilePhoneNumber = "3868675309",
                Ssn = "000-01-0000",

                PrimaryAddress = new PrimaryAddress
                {
                    AddressLine1 = "123 MyStreet",
                    City = "Somehwere",
                    State = "Florida",
                }
            };

            //Act 
            var result = await new CustomerService(new HttpClient()
            {
                BaseAddress = new("https://my.api.mockaroo.com/customers.json?key=e95894a0")
            }).Save(customer);

            //Assert
            Assert.IsTrue(result);
        }
    }
}