using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApiStore.Dtos;
using static WebApiStore.Tools.ToolStr;

namespace WebApiStore.Entities
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Type { get; set; }

        public string Description { get; set; }

        public ICollection<TransactionDetail> Detail { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}



