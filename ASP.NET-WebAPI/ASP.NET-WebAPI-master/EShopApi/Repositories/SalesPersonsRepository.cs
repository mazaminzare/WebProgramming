using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopApi.Contracts;
using EShopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopApi.Repositories
{
    public class SalesPersonsRepository:ISalesPersonsRepository
    {
        private EShopApi_DBContext _context;

        public SalesPersonsRepository(EShopApi_DBContext context)
        {
            _context = context;
        }

        public IEnumerable<SalesPerson> GetAll()
        {
            return _context.SalesPersons.ToList();
        }

        public async Task<SalesPerson> Add(SalesPerson sales)
        {
            await _context.SalesPersons.AddAsync(sales);
            await _context.SaveChangesAsync();
            return sales;
        }

        public async Task<SalesPerson> Find(int id)
        {
            return await _context.SalesPersons.SingleOrDefaultAsync(s => s.SalesPersonId == id);

        }

        public async Task<SalesPerson> Update(SalesPerson sales)
        {
            _context.Update(sales);
            await _context.SaveChangesAsync();
            return sales;
        }

        public async Task<SalesPerson> Remove(int id)
        {
            var sales = await _context.SalesPersons.SingleAsync(s => s.SalesPersonId == id);
            _context.SalesPersons.Remove(sales);
            await _context.SaveChangesAsync();
            return sales;
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.SalesPersons.AnyAsync(s => s.SalesPersonId == id);
        }
    }
}
