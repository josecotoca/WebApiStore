using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiStore.Core.Entities;
using WebApiStore.Core.Repositories.Base;

namespace WebApiStore.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductByNameAsync(string name);

    }
}
