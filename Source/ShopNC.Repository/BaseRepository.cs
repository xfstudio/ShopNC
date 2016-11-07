using ShopNC.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopNC.Repository
{
    //数据访问层基类
    public class BaseRepository<T> where T : class,new()
    {
        //解耦了 当前UserInfoRepository跟上下文的直接依赖。
        //保证了线程内上下文的实例唯一

        private static IDBContextFactory dbContextFactory = new EFContextFactory();

        static DbContext db;
        static BaseRepository()
        {
            db = dbContextFactory.GetCurrentContextInstence();

        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            if (entity != null)
            {
                db.Set<T>().Add(entity);
                db.SaveChanges();

            }
            return entity;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Modified;

            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// 删除实体 删除的时候只需要给主键赋值就可以
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {

            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Deleted;

            db.SaveChanges();
            return  true;

        }

        /// <summary>
        /// 根据条件获取实体列表(不分页)
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntity(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda);
        }

        /// <summary>
        /// 根据条件获取实体列表(分页)
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <param name="orderLambda"></param>
        /// <param name="ifAsc"></param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntity<S>(Expression<Func<T, bool>> whereLambda, int? pageIndex, int? pageSize, out int total, Expression<Func<T, S>> orderLambda, bool isAsc)
        {
            int index = pageIndex ?? 1;
            int size = pageSize ?? 10;

            var data = db.Set<T>().Where<T>(whereLambda);

            total = data.Count();

            data = isAsc ? data.OrderBy(orderLambda) : data.OrderByDescending(orderLambda);
            data = data.Skip<T>(size * (index - 1)).Take<T>(size);

            return data;
        }
    }
}
