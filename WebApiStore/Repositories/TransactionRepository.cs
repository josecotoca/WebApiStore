using WebApiStore.Context;
using WebApiStore.Entities;
using WebApiStore.Interfaces;
using static WebApiStore.Tools.ToolStr;

namespace WebApiStore.Repositories
{
    public class TransactionRepository: ITransaction
    {
        private readonly DataBaseContext context;

        public TransactionRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task Add(Transaction transaction)
        {
            await context.Transactions.AddAsync(transaction);
            await this.Save();
        }

        private async Task Save()
        {
            await this.context.SaveChangesAsync();
        }

        public IEnumerable<Transaction> GetAll()
        {
            var transactions = this.context.Transactions.ToArray();
            return transactions;
        }

        public async Task<bool> ExistsById(int id)
        {
            var transaction = await this.context.Transactions.FindAsync(id);

            return transaction == null ? false : true;
        }

        public async Task<Transaction> GetById(int id)
        {
            return await context.Transactions.FindAsync(id);
        }

        public async Task Delete(Transaction transaction)
        {
            this.context.Transactions.Remove(transaction);

            await Save();
        }
    }
}
