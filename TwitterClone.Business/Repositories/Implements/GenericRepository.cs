using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Repositories.Interfaces;
using TwitterClone.Core.Entities.Common;
using TwitterClone.DatabaseAccessLayer.Contexts;

namespace TwitterClone.Business.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        TwitterCloneDbContext _context { get; }

        public GenericRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool IsTracking = true)
            => IsTracking ? Table.AsNoTracking() : Table;

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        {
            return await Table.AnyAsync(expression);

            // Other alternative (not recommend while AnyAsync() can be used):
            /* return await Table.CountAsync(expression) > 0; */
        }

        public async Task CreateAsync(T data)
        {
            await Table.AddAsync(data);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
