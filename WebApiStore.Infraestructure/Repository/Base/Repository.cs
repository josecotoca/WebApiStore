using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApiStore.Core.Entities.Base;
using WebApiStore.Core.Repositories.Base;
using WebApiStore.Infraestructure.Data;

namespace WebApiStore.Infraestructure.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly WebApiStoreContext dbContext;

        public Repository(WebApiStoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        virtual public async Task<T> AddAsync(T entity)
        {
            dbContext.Set<T>().Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }
               
        public async Task UpdateAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public string GenerateCode(string prefix = "", string value = "", int numChar = 1)
        {
            return prefix + value.PadLeft(numChar, '0');
        }
    }
}
