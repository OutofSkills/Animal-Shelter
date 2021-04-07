using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalShelter.Shared
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(0,9999)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [Range(0,50)]
        public int VatPercentage { get; set; }

        [NotMapped]
        public decimal NetPrice => Price * (1 + (VatPercentage / (decimal)100));

        [Required]
        [Url(ErrorMessage ="This is not a valid Url")]
        public string ProductImageUrl { get; set; }
    }
}
