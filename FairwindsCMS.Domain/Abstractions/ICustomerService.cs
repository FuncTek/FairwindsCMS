using FairwindsCMS.Domain.Models;

namespace FairwindsCMS.Domain.Abstractions
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAll();
        Task<bool> Save(Customer customer);
    }
}
