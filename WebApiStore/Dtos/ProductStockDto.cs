using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace WebApiStore.Dtos
{
    public class ProductStockDto : ProductDto
    {
        public int Stock { get; set; }

    }
}
