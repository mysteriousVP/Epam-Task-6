using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OrderToReturnDTO
    {
        public int OrderId { get; set; }
        public int OrderIdentNumber { get; set; }
        public ICollection<ProductToCreateDTO> Products { get; set; }
        public string Review { get; set; }
    }
}
