using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopNC.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopNC.Entity.Mapping;
using ShopNC.IRepository;
namespace ShopNC.Repository.Tests
{
    [TestClass()]
    public class BaseRepositoryTests
    {
        IUserInfoRepository userDal = new UserInfoRepository();

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

            Assert.IsTrue(userDal.AddEntity(user).ID > 0);
        }

        [TestMethod()]
        public void UpdateEntityTest()
        {

            UserInfo user = userDal.LoadEntity(p => true).FirstOrDefault();
            user.UserName = "updatename";

            Assert.IsTrue(userDal.UpdateEntity(user));

        }

        [TestMethod()]
        public void DeleteEntityTest()
        {
            UserRole role = new UserRole()
            {
                CNName = "Admin",
                ENName = "普通管理员"
            };
            UserInfo user = new UserInfo()
            {
                UserName = "test2",
                Password = "111111",
                Roles = new List<UserRole>() { role }
            };
            userDal.AddEntity(user);
            Assert.IsTrue(userDal.DeleteEntity(user));
        }

        [TestMethod()]
        public void LoadEntityTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadPageEntityTest()
        {
            int count = 0;
            var result=  userDal.LoadPageEntity(p => true, 1, 1, out count, p => p.ID, true);

            Assert.IsTrue(count>0);
            Assert.IsTrue(result.Count() ==1);
        }
    }
}
