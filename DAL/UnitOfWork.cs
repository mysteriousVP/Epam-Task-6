using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IProviderRepository _providerRepository;
        private IOrderRepository _orderRepository;

        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository ?? new CategoryRepository(_context);
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                return _orderRepository ?? new OrderRepository(_context);
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository ?? new ProductRepository(_context);
            }
        }

        public IProviderRepository ProviderRepository
        {
            get
            {
                return _providerRepository ?? new ProviderRepository(_context);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
