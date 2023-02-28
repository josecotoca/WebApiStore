using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApiStore.Application.Interfaces;
using WebApiStore.Core.Entities;
using WebApiStore.Core.Repositories;

namespace WebApiStore.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository) {
            this.productRepository = productRepository;
        }

        private async Task ValidateProductIfExistByName(string productName)
        {
            var existingEntity = await productRepository.GetProductByNameAsync(productName);
            if (existingEntity.Count() > 0)
                throw new ApplicationException("Este producto ya existe.");
        }

        private async Task ValidateProductIfNoExist(int productId)
        {
            var existingEntity = await productRepository.GetByIdAsync(productId);
            if (existingEntity == null)
                throw new ApplicationException("No existe el producto.");
        }

        public async Task<Product> Create(Product product)
        {
            await ValidateProductIfExistByName(product.Name);

            var newEntity = await productRepository.AddAsync(product);
            return newEntity;
        }

        public async Task Update(Product product)
        {
            await ValidateProductIfNoExist(product.Id);

            var editProduct = await productRepository.GetByIdAsync(product.Id);
            if (editProduct == null)
                throw new ApplicationException("La entidad no se há podido cargar.");

            editProduct.Name = product.Name;
            editProduct.Description = product.Description;
            editProduct.Price = product.Price;
            editProduct.Category = product.Category;
            editProduct.forSale = product.forSale;
            editProduct.isService = product.isService;

            await productRepository.UpdateAsync(editProduct);
        }

        public async Task Delete(int productId)
        {
            await ValidateProductIfNoExist(productId);
            var deleteProduct = await productRepository.GetByIdAsync(productId);
            if (deleteProduct == null)
                throw new ApplicationException("La entidad no se há podido cargar.");

            await productRepository.DeleteAsync(deleteProduct);
        }

        public async Task<Product> GetProductById(int productId)
        {
            await ValidateProductIfNoExist(productId);
            var product = await productRepository.GetByIdAsync(productId);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            var productList = await productRepository.GetProductByNameAsync(name);
            return productList;
        }

        public async Task<IEnumerable<Product>> GetProductList()
        {
            var productList = await productRepository.GetAllAsync();
            return productList;
        }
    }
}
