using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProviderName { get; set; }
    }
}
