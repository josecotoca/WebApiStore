using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebApiStore.Dtos.Base;

namespace WebApiStore.Dtos.Product
{
    public class ProductCreateDto
    {
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
