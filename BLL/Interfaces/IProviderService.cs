using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProviderService
    {
        Task<ProviderToReturnDTO> Get(int id);
        Task<IEnumerable<ProviderToReturnDTO>> Get();
        ProviderToReturnDTO Post(ProviderToCreateDTO provider);
        bool Put(ProviderToCreateDTO provider, int id);
        Task<bool> Delete(int id);
    }
}
