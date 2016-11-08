using ShopNC.Entity.Mapping;
using ShopNC.IRepository;
using ShopNC.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNCTest
{
    class Program
    {
       static IUserInfoRepository userDal = new UserInfoRepository();
        static void Main(string[] args)
        {
            var pros = typeof(ShopNCContext).GetProperties();
            foreach (var pro in pros)
            {
                var typeName = pro.GetGetMethod().ReturnType.Name;
                if (typeName == "DbSet`1")
                {
                    
                }
            }
        }
    }
}
