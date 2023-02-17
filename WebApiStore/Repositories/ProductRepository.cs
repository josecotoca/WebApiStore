using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApiStore.Context;
using WebApiStore.Entities;
using WebApiStore.Interfaces;
using WebApiStore.Tools;

namespace WebApiStore.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly DataBaseContext context;

        public ProductRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task Add(Product product) {
            
            await this.context.Products.AddAsync(product);
            product.Code = this.GenerateCode(product.Id.ToString());

            await this.Save();
        }

        public async Task Update(Product product)
        {
            this.context.Products.Update(product);

            await this.Save();
        }

        public async Task Delete(Product product)
        {
            this.context.Products.Remove(product);

            await Save();
        }

        public IEnumerable<Product> GetAll()
        {
            var products = this.context.Products.ToArray();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await this.context.Products.FindAsync(id);

            return product;
        }

        public async Task<bool> ExistsById(int id)
        {
            var product = await this.context.Products.FindAsync(id);

            return product == null ? false : true;
        }

        public async Task<bool> ExistsByName(string name)
        {
            var product = this.context.Products
                    .Where(b => b.Name == name)
                    .FirstOrDefault();

            if (product == null) return false;

            return true;
        }

        private string GenerateCode(string id)
        {
            return ToolStr.GenerateCode("PRO-", id, 6);
        }

        private async Task Save()
        {
            await this.context.SaveChangesAsync();
        }

    }
}