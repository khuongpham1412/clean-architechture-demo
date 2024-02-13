using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageSystem.Application.Contracts.Services;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models.Customer.Ins;

namespace StorageSystem.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) 
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CreateCustomerInsDto customerDto)
        {
            var result = await _customerService.CreateCustomer(customerDto);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                BadRequest
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer([FromQuery] FilterCustomer filter)
        {
            var result = await _customerService.GetAllCustomers(filter);
            return result.Match<IActionResult>(
                res => Ok(new
                {
                    res.Customers,
                    res.Total
                }),
                BadRequest,
                BadRequest
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindCustomerById(Guid id)
        {
            var result = await _customerService.FindCustomerById(id);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                res => BadRequest(res)
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerInsDto customer)
        {
            var result = await _customerService.UpdateCustomer(id, customer);
            return result.Match<IActionResult>(
                _ => NoContent(),
                BadRequest,
                BadRequest
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var result = await _customerService.DeleteCustomer(id);
            return result.Match<IActionResult>(
                _ => NoContent(),
                r1 => Ok(result.AsT1),
                r2 => Ok(result.AsT2)
            );
        }
    }
}
