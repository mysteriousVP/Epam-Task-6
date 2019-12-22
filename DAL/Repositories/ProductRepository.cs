using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return _dataContext.Products.Include(p => p.Categories)
                .ThenInclude(p => p.Category)
                .Include(p => p.Provider);
        }
    }
}
