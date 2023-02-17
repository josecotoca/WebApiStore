using Microsoft.EntityFrameworkCore;
using WebApiStore.Entities;
using WebApiStore.Interfaces;

namespace WebApiStore.Context
{
    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "dbStore");
            optionsBuilder.UseTriggers(triggerOptions => {
                triggerOptions.AddTrigger<SoftDeleteTrigger>();
            });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
    }
}