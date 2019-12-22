using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryToReturnDTO> Get(int id);
        Task<IEnumerable<CategoryToReturnDTO>> Get();
        CategoryToReturnDTO Post(CategoryToCreateDTO category);
        bool Put(CategoryToCreateDTO category, int id);
        Task<bool> Delete(int id);
    }
}
