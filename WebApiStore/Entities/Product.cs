using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using WebApiStore.Interfaces;

namespace WebApiStore.Entities
{
    public class Product : ISoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }
        public int Stock { get; set; }

        public bool forSale { get; set; }

        public bool isService { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
