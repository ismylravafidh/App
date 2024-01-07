using App.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity , new()
    {
        DbSet<T> Table { get; }
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>? orderbyExpression = null,
            bool isDescinding = false,
            params string[]? includes);
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
