using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        public string ProductAbout { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public ICollection<Product_Category> Categories { get; set; }
        [Required]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}
