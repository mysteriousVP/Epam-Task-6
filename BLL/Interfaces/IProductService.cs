using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        Task<ProductToReturnDTO> Get(int id);
        Task<IEnumerable<ProductToReturnDTO>> Get();
        ProductToReturnDTO Post(ProductToCreateDTO product);
        bool Put(ProductToCreateDTO product, int id);
        Task<bool> Delete(int id);
    }
}
