using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopNC.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopNC.IService;
using ShopNC.Entity.Mapping;
using ShopNC.IRepository;
using Autofac;
namespace ShopNC.Service.Tests
{
    [TestClass()]
    public class BaseServiceTests
    {
       
        IUserInfoService bll = new UserInfoService();

        [TestMethod()]
        public void AddEntityTest()
        {
            UserRole role = new UserRole()
            {
                CNName = "Admin",
                ENName = "普通管理员"
            };
            UserInfo user = new UserInfo()
            {
                UserName = "test1",
                Password = "111111",
                Roles = new List<UserRole>() { role }
            };
            bll.AddEntity(user);
           var result=bll.DBSession.SaveChanges();

            Assert.IsTrue(user.ID > 0);
            Assert.IsTrue(result > 0);
        }

        [TestMethod()]
        public void BaseServiceTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void UpdateEntityTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteEntityTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadEntityTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadPageEntityTest()
        {
            Assert.Fail();
        }
    }
}
