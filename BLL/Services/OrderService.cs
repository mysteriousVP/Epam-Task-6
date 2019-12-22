using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            Order order = await _unitOfWork.OrderRepository.Get(id);

            if (order == null)
            {
                return false;
            }

            return _unitOfWork.OrderRepository.Remove(order);
        }

        public async Task<OrderToReturnDTO> Get(int id)
        {
            Order order = await _unitOfWork.OrderRepository.Get(id);

            return _mapper.Map<OrderToReturnDTO>(order);
        }

        public async Task<IEnumerable<OrderToReturnDTO>> Get()
        {
            IEnumerable<Order> orders = await _unitOfWork.OrderRepository.GetAll();

            return _mapper.Map<IEnumerable<OrderToReturnDTO>>(orders);
        }

        public OrderToReturnDTO Post(OrderToCreateDTO orderToCreate)
        {
            Order order = _mapper.Map<Order>(orderToCreate);

            if (_unitOfWork.OrderRepository.Add(order) == true)
            {
                return _mapper.Map<OrderToReturnDTO>(order);
            }

            throw new ArgumentException("Fail on creation");
        }

        public async Task<IEnumerable<ProductToReturnDTO>> ProductsOfOrder(int id)
        {
            Order order = await _unitOfWork.OrderRepository.Get(id);
            return _mapper.Map<IEnumerable<ProductToReturnDTO>>(
               order.Products);
        }

        public bool Put(OrderToCreateDTO orderToCreate, int id)
        {
            Order order = _mapper.Map<Order>(orderToCreate);
            order.OrderId = id;

            return _unitOfWork.OrderRepository.Update(order);
        }

        public async Task<bool> PutProductToOrder(ProductToCreateDTO productToCreate, int id)
        {
            Product product = _mapper.Map<Product>(productToCreate);
            Order order = await _unitOfWork.OrderRepository.Get(id);
            order.Products.Add(product);

            return _unitOfWork.OrderRepository.Update(order);
        }
    }
}
