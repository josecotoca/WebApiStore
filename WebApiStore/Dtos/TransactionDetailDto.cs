using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace WebApiStore.Dtos
{
    public class TransactionDetailDto
    {
        public int id { get; set; }

        [Required]
        [DefaultValue(1)]
        public int ProductId { get; set; }

        [Required]
        [DefaultValue(50)]
        public int Quantity { get; set; }
    }
}
