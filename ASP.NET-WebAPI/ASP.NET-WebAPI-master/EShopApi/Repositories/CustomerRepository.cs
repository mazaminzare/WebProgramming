using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopApi.Contracts;
using EShopApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EShopApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private EShopApi_DBContext _context;
        private IMemoryCache _cache;
        public CustomerRepository(EShopApi_DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache; 
        }


        public async Task<Customer> Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Find(int id)
        {
            var cacheCustomer = _cache.Get<Customer>(id);

            if (cacheCustomer != null)
            {
                return cacheCustomer;
            }

            else 
            {
                var customer = await _context.Customers.Include(c => c.Orders).SingleOrDefaultAsync(c => c.CustomerId == id);
                var cacheOption = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60));
                _cache.Set(customer.CustomerId,customer, cacheOption);

                return customer;
            
            }

        }

        //public IEnumerable<Customer> GetAll()
        //{
        //    return _context.Customer.ToList();
        //}
        public IEnumerable<Customer> GetAll() { 
        
            return _context.Customers.ToList();
        //{
        //    var cacheCustomer = _cache.Get<Customer>(_context.Entry);
        //    if (cacheCustomer != null)
        //    {
        //        yield return cacheCustomer;
        //    }
        //    else 
        //    {
        //        var customers = _context.Customers ;

        //        var cacheOption = new MemoryCacheEntryOptions()
        //        .SetSlidingExpiration(TimeSpan.FromSeconds(60));
        //        _cache.Set(customers, customers.ToList(), cacheOption);

            }


    //}

    public async Task<bool> IsExists(int id)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerId == id);
        }

        public async Task<int> CountCustomer()
        {
            return await _context.Customers.CountAsync();
        }

        public async Task<Customer> Remove(int id)
        {
            var customer = await _context.Customers.SingleAsync(c => c.CustomerId == id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
