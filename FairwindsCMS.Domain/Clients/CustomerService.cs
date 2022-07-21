using FairwindsCMS.Domain.Abstractions;
using FairwindsCMS.Domain.Models;
using Newtonsoft.Json;
using System.Text;

namespace FairwindsCMS.Domain.Clients
{
    public class CustomerService : ICustomerService
    {
        private const string MediaType = "application/json";
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<Customer>> GetAll()
        {
            List<Customer> customerList = new();
#if DEBUG
            if (customerList.Count <= 0)
            {
                customerList.Add(new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    DateBirth = Convert.ToDateTime("11/01/2000"),
                    CustomerNumber = 012345,
                    Email = "John.Doe@mailthem.org",
                    JoinDate = DateTime.Today,
                    MobilePhoneNumber = "386-867-5309",
                    Ssn = "001-00-0001",
                    PrimaryAddress = new PrimaryAddress
                    {
                        AddressLine1 = "1213 Some Street",
                        City = "Nowhere",
                        State = "Florida",
                        ZipCode = "98754"
                    }
                });
                customerList.Add(new Customer
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateBirth = Convert.ToDateTime("01/01/1997"),
                    CustomerNumber = 03456,
                    Email = "Jane.Doe@mailthem.org",
                    JoinDate = DateTime.Today,
                    MobilePhoneNumber = "386-555-5555",
                    Ssn = "001-00-0002",
                    PrimaryAddress = new PrimaryAddress
                    {
                        AddressLine1 = "3121 Some Street",
                        City = "Nowhere",
                        State = "Florida",
                        ZipCode = "98754"
                    }
                });
            }
            return customerList;
#endif
            HttpResponseMessage response = await _httpClient.GetAsync(string.Empty);

            if (response.IsSuccessStatusCode)
            {
                customerList = JsonConvert.DeserializeObject<List<Customer>>(response.Content.ReadAsStringAsync().Result) ?? new ();
            }
            else
            {
                //Log out inability to reach endpoint.
            }

            return customerList;
        }

        public async Task<bool> Save(Customer customer)
        {
            var jsonString = JsonConvert.SerializeObject(customer);
            var content = new StringContent(jsonString, Encoding.UTF8, MediaType);
            var response = await _httpClient.PostAsync("", content);
            return response.IsSuccessStatusCode;
        }
    }
}