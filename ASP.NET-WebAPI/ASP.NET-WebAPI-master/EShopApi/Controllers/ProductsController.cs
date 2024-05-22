using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EShopApi.Models;
using EShopApi.Contracts;

namespace EShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }

        // GET: api/Products
        [HttpGet]
        public  IEnumerable<Product> GetProducts()
        {
            return  _productRepository.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var product = await _productRepository.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id,[FromBody] Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            await _productRepository.Update(product);

           
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            if (ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            await _productRepository.Add(product);
            

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var product = await _productRepository.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.Remove(id);
            

            return NoContent();
        }

        private async Task<bool> ProductExists(int id)
        {
            return await _productRepository.IsExists(id);
        }
    }
}
