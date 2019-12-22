using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(10)]
        public string OrderIdentNumber { get; set; }
        [Required]
        public ICollection<Product> Products { get; set; }
        public string Review { get; set; }
    }
}
