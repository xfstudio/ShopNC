using Autofac;
using ShopNC.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using ShopNC.Service;

namespace ShopNC.Web
{
    public class ServiceContainer
    {
        private static object o = new object();
        private static ContainerBuilder containerBuilder = null;
        public static void RegisterContainer()
        {
            if (containerBuilder == null)
            {
                lock (o)
                {
                    containerBuilder = new ContainerBuilder();
                    containerBuilder.RegisterType<UserInfoService>().As<IUserInfoService>().SingleInstance();
                    containerBuilder.RegisterType<UserRoleService>().As<IUserRoleService>().SingleInstance();

                   // Scan an assembly for components 查找程序集中以services结尾的类型 不要使用这种方式注册 不保险
                    /* containerBuilder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                        .Where(t => t.Name.EndsWith("Service"))
                        .AsImplementedInterfaces().SingleInstance();*/

                }
            }

            //  containerBuilder.Build();
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly());  //注入所有Controller
            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //解决Controller 没有为该对象定义无参数的构造函数
        }

    }
}
