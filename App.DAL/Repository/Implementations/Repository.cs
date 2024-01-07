using App.Core.Entities.Base;
using App.DAL.Common;
using App.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, Expression<Func<T, object>>? orderbyExpression = null, bool isDescinding = false, params string[]? includes)
        {
            IQueryable<T> query = Table.Where(c => c.IsDeleted == false);
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (orderbyExpression != null)
            {
                query = isDescinding ? query.OrderByDescending(orderbyExpression) : query.OrderBy(orderbyExpression);
            }
            if (includes != null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query.ToList();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FirstOrDefaultAsync(p => p.Id == id);
        }


        public DbSet<T> Table => _context.Set<T>();
        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
        }
        public async Task UpdateAsync(T entity)
        {
             Table.Update(entity);
        }
        public async Task DeleteAsync(T entity)
        {
            Table.Update(entity);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
