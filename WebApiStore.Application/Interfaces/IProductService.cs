using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiStore.Core.Entities;

namespace WebApiStore.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductList();

        Task<Product> GetProductById(int id);

        Task<IEnumerable<Product>> GetProductByName(string name);

        Task<Product> Create(Product product);

        Task Update(Product product);

        Task Delete(int productId);
    }
}
