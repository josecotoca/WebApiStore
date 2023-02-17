using WebApiStore.Entities;

namespace WebApiStore.Interfaces
{
    public interface IProduct
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Product product);
        IEnumerable<Product> GetAll();
        Task<Product> GetById(int id);
        Task<bool> ExistsById(int id);
        Task<bool> ExistsByName(string name);
    }
}
