using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiStore.Core.Entities.Base;

namespace WebApiStore.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }
        public int Stock { get; set; }

        public bool forSale { get; set; }

        public bool isService { get; set; }
    }
}
