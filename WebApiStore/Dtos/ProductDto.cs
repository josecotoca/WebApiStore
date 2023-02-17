using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApiStore.Dtos
{
    public class ProductDto
    {
        [Required]
        [DefaultValue(0)]
        public int Id { get; set; }
        [DefaultValue("")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        [DefaultValue("POLERA HERING BLANCA")]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        [DefaultValue("POLERA DE ALGODON UNISEX COLOR BLANCA SENCILLA")]
        public string Description { get; set; }

        [MaxLength(150)]
        [DefaultValue("POLERAS")]
        public string Category { get; set; }

        [Required]
        [DefaultValue(120)]
        public double Price { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool ForSale { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsService { get; set; }
        
    }
}
