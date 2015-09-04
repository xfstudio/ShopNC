using Autofac;
using ShopNC.IRepository;
using ShopNC.IService;
using ShopNC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNC.Service
{
    public class BaseService<T>:IBaseService<T>
        where T:class,new()
    {

        public static IDBSession session = null;

        public IDBSession DBSession
        {
            get { return session; }
        }
       /* static BaseService() 
        {
            if (session==null)
            {
               // session=new RepositoryContainner().Container.Resolve<IDBSession>();
                //此版本Autofac自动Resolve？
                RepositoryContainner.DisposeContainer();
            }
        }*/

        public IBaseRepository<T> baseRepository = new RepositoryContainner().GetBaseRepository<T>();
        public T AddEntity(T entity)
        {
            baseRepository.AddEntity(entity);
 
            return entity;
        }

        public bool UpdateEntity(T entity)
        {
            baseRepository.AddEntity(entity);

            return true;
        }

        public bool DeleteEntity(T entity)
        {
            baseRepository.DeleteEntity(entity);

            return true;
        }

        public IQueryable<T> LoadEntity(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
           return baseRepository.LoadEntity(whereLambda);
        }

        public IQueryable<T> LoadPageEntity<S>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, int? pageIndex, int? pageSize, out int total, System.Linq.Expressions.Expression<Func<T, S>> orderLambda, bool isAsc)
        {
            return baseRepository.LoadPageEntity(whereLambda, pageIndex, pageSize, out total, orderLambda, isAsc);
        }
    }
}
