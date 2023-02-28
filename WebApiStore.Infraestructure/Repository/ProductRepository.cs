using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiStore.Core.Entities;
using WebApiStore.Core.Repositories;
using WebApiStore.Infraestructure.Data;
using WebApiStore.Infraestructure.Repository.Base;

namespace WebApiStore.Infraestructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(WebApiStoreContext dbContext) : base(dbContext) {
        
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string name)
        {
            return await dbContext.Products
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
        }

        override public async Task<Product> AddAsync(Product entity)
        {
            dbContext.Set<Product>().Add(entity);
            entity.Code = GenerateCode("PRO-", entity.Id.ToString(), 8);
            await dbContext.SaveChangesAsync();
            return entity;
        }

    }
}
