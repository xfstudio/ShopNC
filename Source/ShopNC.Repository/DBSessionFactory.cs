using ShopNC.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNC.Repository
{
    public class DBSessionFactory : IDBSessionFactory
    {
        private static IDBSession dbSession = null;
        static DBSessionFactory()
        {
            dbSession = new DBSession();
        }
        public IDBSession GetDBSession()
        {
            return dbSession;
        }
    }
}
