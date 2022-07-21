using FairwindsCMS.Domain.Abstractions;
using FairwindsCMS.Domain.Models;
using FairwindsCMS.Web.Abstractions;
using FairwindsCMS.Web.Infrastructure;
using FairwindsCMS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FairwindsCMS.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerRepository;
        private readonly IDataService _dataService;

        public CustomerController(ICustomerService customerRepository, IDataService dataService)
        {
            _customerRepository = customerRepository;
            _dataService = dataService;
        }

        // GET: CustomerController
        public async Task<IActionResult> AllCustomers()
        {
            var allCustomers = await _customerRepository.GetAll();
            allCustomers = _dataService.CleanSSN(allCustomers);
            allCustomers = _dataService.CalculateAge(allCustomers);
            return View(allCustomers);
        }

        // GET: CustomerController/Create
        public async Task<IActionResult> Create()
        {
            var customerFormVm = await _dataService.GetCustomerFormVm();
            return View(customerFormVm);
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerFormVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Customer.JoinDate = DateTime.Now;
                    model.Customer.PrimaryAddress = model.PrimaryAddress;
                    bool saveResult = await _customerRepository.Save(model.Customer);

                    if (saveResult)
                    {
                        return RedirectToAction(nameof(AllCustomers));
                    }
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }
    }
}
