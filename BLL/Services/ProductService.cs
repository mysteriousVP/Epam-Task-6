using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            Product product = await _unitOfWork.ProductRepository.Get(id);

            if (product == null)
            {
                return false;
            }

            return _unitOfWork.ProductRepository.Remove(product);
        }

        public async Task<ProductToReturnDTO> Get(int id)
        {
            Product product = await _unitOfWork.ProductRepository.Get(id);

            return _mapper.Map<ProductToReturnDTO>(product);
        }

        public async Task<IEnumerable<ProductToReturnDTO>> Get()
        {
            IEnumerable<Product> products = await _unitOfWork.ProductRepository.GetAll();

            return _mapper.Map<IEnumerable<ProductToReturnDTO>>(products);
        }

        public ProductToReturnDTO Post(ProductToCreateDTO productToCreate)
        {
            Product product = _mapper.Map<Product>(productToCreate);

            if (_unitOfWork.ProductRepository.Add(product) == true)
            {
                return _mapper.Map<ProductToReturnDTO>(product);
            }

            throw new ArgumentException("Fail on creation");
        }

        public bool Put(ProductToCreateDTO productToCreate, int id)
        {
            Product product= _mapper.Map<Product>(productToCreate);
            product.ProductId = id;

            return _unitOfWork.ProductRepository.Update(product);
        }
    }
}
