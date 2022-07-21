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