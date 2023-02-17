using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using WebApiStore.Tools;
using static WebApiStore.Tools.ToolStr;

namespace WebApiStore.Dtos
{
    public class TransactionDto
    {
        [Required]
        [DefaultValue(0)]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [DefaultValue("INGRESO")]
        public string Type { get; set; }

        [Required]
        [DefaultValue("Ingreso inicial de stock")]
        public string Description { get; set; }

        public ICollection<TransactionDetailDto> detail { get; set; }
    }
}
