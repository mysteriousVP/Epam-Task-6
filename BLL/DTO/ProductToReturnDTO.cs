using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ProductToReturnDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductAbout { get; set; }
        public int Price { get; set; }
        public ICollection<CategoryToReturnDTO> Categories { get; set; }
        public ProviderToReturnDTO Provider { get; set; }
    }
}
