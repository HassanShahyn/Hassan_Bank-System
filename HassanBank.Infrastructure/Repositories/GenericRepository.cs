using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HassanBank.Domain.Entities; // ✅ ده المسار الصح للـ Entities
using HassanBank.Domain.Interfaces;
using HassanBank.Infrastructure.Persistence; // ✅ ده المسار الصح للـ DbContext
using Microsoft.EntityFrameworkCore;


namespace HassanBank.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            // ✅ بنرجع بس اللي مش ممسوح (Soft Delete)
            return await dbSet.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();
        }

        // ✅ الاسم الصح AddAsync
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            entity.LastModifiedAt = DateTime.UtcNow;
            entity.LastModifiedBy = "System";
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            // ✅ Soft Delete Logic
            entity.IsDeleted = true;
            entity.LastModifiedAt = DateTime.UtcNow;
            Update(entity);
        }
    }
}