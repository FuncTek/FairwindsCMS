using FairwindsCMS.Domain.Models;
using FairwindsCMS.Web.Models;

namespace FairwindsCMS.Web.Abstractions
{
    public interface IDataService
    {
        List<Customer> CalculateAge(List<Customer> customers);
        List<Customer> CleanSSN(List<Customer> customers);
        Task<CustomerFormVm> GetCustomerFormVm();
    }
}
