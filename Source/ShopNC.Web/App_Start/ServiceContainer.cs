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

                    //containerBuilder.RegisterType<UserInfoService>().As<IUserInfoService>().SingleInstance();
                    //containerBuilder.RegisterType<UserRoleService>().As<IUserRoleService>().SingleInstance();
                    //containerBuilder.RegisterType<PermissionService>().As<IPermissionService>();
                    //containerBuilder.RegisterType<PermissionGroupService>().As<IPermissionGroupService>();
                  
                   // Scan an assembly for components 查找程序集中以services结尾的类型 
                     containerBuilder.RegisterAssemblyTypes(typeof(UserInfoService).Assembly)
                         .Where(t =>t.BaseType!=null&&t.BaseType.Name.StartsWith("BaseService"))
                         .AsImplementedInterfaces().InstancePerLifetimeScope();

                }
            }

            //  containerBuilder.Build();
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly());  //注入所有Controller
            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //解决Controller 没有为该对象定义无参数的构造函数
        }

    }
}
