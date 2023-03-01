using AppCrud.Models;
using AppCrud.Service.CustomersService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppCrud.ApiController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerService CustomerService;
        public CustomerController(ICustomerService CustomerService)
        {
            this.CustomerService = CustomerService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CustomerService.GetList());
        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            return Ok(CustomerService.GetById(id));
        }
        [HttpGet("name")]
        public IActionResult GetListLike(string name)
        {
            return Ok(CustomerService.GetListLike(name));
        }
        [HttpPost]
        public async Task<IActionResult> Insert(Customer customer)
        {
            return Ok(CustomerService.Add(customer));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, Customer customer)
        {
            return Ok(CustomerService.Update(id, customer));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(CustomerService.Delete(id));
        }
    }
}
