using EShopApi.Contracts;
using EShopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Net;


namespace EShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        
        private ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        //[ResponseCache(Duration = 60)]
        public IActionResult GetCustomer()
        {
            
            var result = new ObjectResult(_customerRepository.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            Request.HttpContext.Response.Headers.Add("X-Count", _customerRepository.CountCustomer().ToString());
            Request.HttpContext.Response.Headers.Add("X-Name", "AminZare");

            return result;
        }

        private Task<bool> CustomerExists(int id)
        {
            return _customerRepository.IsExists(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            if (await CustomerExists(id)) 
            {
                var customer = await _customerRepository.Find(id);
                return Ok(customer);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            await _customerRepository.Add(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            await _customerRepository.Update(customer);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            await   _customerRepository.Remove(id);
            return Ok();
        }



    }
}
