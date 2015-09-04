using ShopNC.Entity.Mapping;
using ShopNC.IRepository;
using ShopNC.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ShopNC.Common;

namespace ShopNCTest
{
    class Program
    {
       static IUserInfoRepository userDal = new UserInfoRepository();
        static void Main(string[] args)
        {

            //string modelFile = Path.Combine(@"D:\Git\ShopNC\Source\ShopNC.Entity\bin\Debug\ShopNC.Entity.dll");
            //byte[] fileData = File.ReadAllBytes(modelFile);
            //Assembly assembly = Assembly.Load(fileData);

            Assembly assembly = Assembly.GetAssembly(typeof(EntityBase<int>));
            Type baseType = typeof(EntityBase<int>);
            IEnumerable<Type> modelTypes = assembly.GetTypes().Where(m => m.BaseType.Name == baseType.Name && !m.IsAbstract);
            //可以继承EntityBase<int> 来获取所有Entity，下面通过属性名来判断不是很好的方法

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
