using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        Task<OrderToReturnDTO> Get(int id);
        Task<IEnumerable<OrderToReturnDTO>> Get();
        OrderToReturnDTO Post(OrderToCreateDTO order);
        bool Put(OrderToCreateDTO order, int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<ProductToReturnDTO>> ProductsOfOrder(int id);
        Task<bool> PutProductToOrder(ProductToCreateDTO product, int id);
    }
}
