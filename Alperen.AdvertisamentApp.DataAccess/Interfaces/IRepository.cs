using Alperen.AdvertisamentApp.Common.Enums;
using Alperen.AdvertisamentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity// T BaseEntity Türünden nesneler alabilir.
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, Expression<Func<T, bool>> filter, OrderByType orderByType);
        Task<T> FindAsync(object id);
        Task<T> FindByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        IQueryable<T> GetQuery();
        void Remove(T entity);
        Task CreateAsync(T entity);
        void Update(T entity, T unchanged);
    }
}
