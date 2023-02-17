using System.Xml.Linq;
using WebApiStore.Context;
using WebApiStore.Entities;
using WebApiStore.Interfaces;
using WebApiStore.Tools;
using static WebApiStore.Tools.ToolStr;

namespace WebApiStore.Repositories
{
    public class TransactionDetailRepository : ITransactionDetail
    {
        private readonly DataBaseContext context;

        public TransactionDetailRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task Add(ICollection<TransactionDetail> detail)
        {
            
            foreach (var item in detail)
            {
                context.TransactionDetails.Add(item);
            }
            await this.Save();
        }

        public IEnumerable<TransactionDetail> GetAll()
        {
            var transactions = this.context.TransactionDetails.ToArray();
            return transactions;
        }

        public IEnumerable<TransactionDetail> GetByTransaction(int id)
        {
            var details = this.context.TransactionDetails
                    .Where(b => b.TransactionId == id);

            return details;
        }

        private async Task Save()
        {
            await this.context.SaveChangesAsync();
        }

        public async Task<bool> validateIsProduct(ICollection<TransactionDetail> detail)
        {
            foreach (var item in detail)
            {
                var product = context.Products.Find(item.ProductId);
                if (product == null || product.isService)
                    return false;
                else
                    item.Product = product;
            }

            return true;
        }

        public async Task<bool> hasStockAvailable(ICollection<TransactionDetail> detail)
        {
            foreach (var item in detail)
            {
                if (item.Quantity > item.Product.Stock)
                    return false;
            }

            return true;
        }

        public async Task<bool> moveStock(ICollection<TransactionDetail> detail, int transactionId, string type)
        {
            foreach (var item in detail)
            {
                if (!item.Product.isService)
                    item.Product.Stock = (type == ToolStr.TypeTransaction.INGRESO.ToString()) ? (item.Product.Stock + item.Quantity) : (item.Product.Stock - item.Quantity);

                if (item.Product.Stock < 0)
                    return false;

                this.context.Products.Update(item.Product);
                await this.Save();
            }


            return true;
        }
    }
}
