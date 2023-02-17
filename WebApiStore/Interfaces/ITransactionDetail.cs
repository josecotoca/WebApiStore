using WebApiStore.Dtos;
using WebApiStore.Entities;

namespace WebApiStore.Interfaces
{
    public interface ITransactionDetail
    {
        IEnumerable<TransactionDetail> GetAll();

        IEnumerable<TransactionDetail> GetByTransaction(int id);

        Task<bool> validateIsProduct(ICollection<TransactionDetail> detail);

        Task<bool> hasStockAvailable(ICollection<TransactionDetail> detail);

        Task<bool> moveStock(ICollection<TransactionDetail> detail, int transactionId, string type);
        Task Add(ICollection<TransactionDetail> detail);
    }
}
