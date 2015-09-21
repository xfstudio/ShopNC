using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopNC.IRepository;

namespace ShopNC.IService
{
    public interface IBaseService<T> where T :
         class ,new()
    {

        T AddEntity(T entity);

        bool UpdateEntity(T entity);

        bool DeleteEntity(T entity);

        IQueryable<T> LoadEntity(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> LoadPageEntity<S>(Expression<Func<T, bool>> whereLambda, int? pageIndex, int? pageSize, out int total, Expression<Func<T, S>> orderLambda, bool isAsc);
        

        #region 异步Task
        Task<T> AddEntityAsync(T entity);

        Task<bool> UpdateEntityAsync(T entity);

        Task<bool> DeleteEntityAsync(T entity);

        Task<IQueryable<T>> LoadEntityAsync(Expression<Func<T, bool>> whereLambda);

        Task<IQueryable<T>> LoadPageEntityAsync<S>(Expression<Func<T, bool>> whereLambda, int? pageIndex, int? pageSize, out int total, Expression<Func<T, S>> orderLambda, bool isAsc);

        #endregion


    }
}
