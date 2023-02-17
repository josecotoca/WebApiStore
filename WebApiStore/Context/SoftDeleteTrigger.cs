using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore;
using WebApiStore.Interfaces;

namespace WebApiStore.Context
{
    public class SoftDeleteTrigger : IBeforeSaveTrigger<ISoftDelete>
    {
        readonly DbContext dbContext;
        public SoftDeleteTrigger(DbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task BeforeSave(ITriggerContext<ISoftDelete> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Deleted)
            {
                var entry = dbContext.Entry(context.Entity);
                context.Entity.DeletedAt = DateTime.UtcNow;
            }

            await Task.CompletedTask;
        }
    }
}
