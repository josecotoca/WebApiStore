using WebApiStore.Dtos;
using WebApiStore.Entities;

namespace WebApiStore.Interfaces
{
    public interface ITransaction
    {
        Task Add(Transaction transaction);

        IEnumerable<Transaction> GetAll();

        Task<bool> ExistsById(int id);
        Task<Transaction> GetById(int id);

        Task Delete(Transaction transaction);
    }
}
