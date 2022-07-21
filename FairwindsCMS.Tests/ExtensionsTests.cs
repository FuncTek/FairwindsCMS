using FairwindsCMS.Domain.Models;
using FairwindsCMS.Domain.Clients;
using FairwindsCMS.Web.Infrastructure;

namespace FairwindsCMS.Tests
{
    [TestClass]
    public class DataServiceTests
    {
        [TestMethod]
        public async Task Can_Clean_Customer_SSN()
        {
            //Arrange 
            List<Customer> customers = await new CustomerService(new HttpClient()
            {
                BaseAddress = new("https://my.api.mockaroo.com/customers.json?key=e95894a0")
            }).GetAll();

            //Act 
            List<string> ssns = new List<string>();

            foreach (var item in customers.Where(x => !string.IsNullOrWhiteSpace(x.Ssn)))
            {
                ssns.Add(item.Ssn.GetLastFour());
            }

            //Assert    
            Assert.IsTrue(ssns.Where(x => !string.IsNullOrWhiteSpace(x)).All(n => n.Length == 4));
        }

        [TestMethod]
        public void Can_Get_Accurate()
        {
            //Arrange 
            DateTime bday = Convert.ToDateTime("11/01/2000");// Birth month not arrived
            DateTime bday2 = Convert.ToDateTime("1/01/2000");// Birth month arrived
            DateTime bday3 = Convert.ToDateTime($"{DateTime.Now.Month}/{DateTime.Now.Day}/2000");// Birth month arrived
            DateTime bday4 = DateTime.Today;// Birthday today

            //Act 
            int age = bday.CalculateAge();
            int age2 = bday2.CalculateAge();
            int age3 = bday3.CalculateAge();
            int age4 = bday4.CalculateAge();


            //Assert
            Assert.IsTrue(age == 21);
            Assert.IsTrue(age2 == 22);
            Assert.IsTrue(age3 == 22);
            Assert.IsTrue(age4 == 0);
        }
    }
}