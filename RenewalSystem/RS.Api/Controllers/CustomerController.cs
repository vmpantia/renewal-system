using Microsoft.AspNetCore.Mvc;
using RS.BAL.Models;
using RS.BAL.Services;

namespace RS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customer;
        public CustomerController(CustomerService customer)
        {
            _customer = customer;   
        }

        [HttpGet]
        public IActionResult GetOne()
        {
            var result = _customer.GetAll<CustomerDto>();
            return Ok(result);
        }

        [HttpGet("{customerId}")]
        public IActionResult GetOne(Guid customerId)
        {
            var result = _customer.GetOne<CustomerDto>(data => data.Id == customerId);
            return Ok(result);
        }
    }
}
