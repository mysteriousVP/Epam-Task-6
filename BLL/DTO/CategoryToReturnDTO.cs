using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CategoryToReturnDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductToReturnDTO> Products { get; set; }
    }
}
