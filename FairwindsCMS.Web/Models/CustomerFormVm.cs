using FairwindsCMS.Domain.Models;

namespace FairwindsCMS.Web.Models
{
    public class CustomerFormVm
    {
        public Customer? Customer { get; set; }
        public PrimaryAddress? PrimaryAddress{ get; set; }
            
    }
}
