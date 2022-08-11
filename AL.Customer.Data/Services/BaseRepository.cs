using AL.Customer.Data.DbModels;
using AL.Customer.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AL.Customer.Data.Services
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly FirstMarketContext db;

        public BaseRepository(FirstMarketContext context) =>
            db = context;

        public virtual async Task Add(TEntity obj)
        {
            db.Add(obj);
            await db.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll() =>
            await db.Set<TEntity>().ToListAsync();

        public virtual async Task<TEntity> GetById(int? id) =>
            await db.Set<TEntity>().FindAsync(id);

        public virtual async Task Remove(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
            await db.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public void Dispose() =>
            db.Dispose();
    }
}
