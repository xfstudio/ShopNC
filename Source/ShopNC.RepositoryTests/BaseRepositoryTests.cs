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
         static IDBSession session = new DBSessionFactory().GetDBSession();
         IUserInfoRepository userDal = session.UserInfoRepository;

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
            userDal.AddEntity(user);
            var result= session.SaveChanges();


            Assert.IsTrue(user.ID > 0);
            Assert.IsTrue(result > 0);

        }

        [TestMethod()]
        public void UpdateEntityTest()
        {

            UserInfo user = userDal.LoadEntity(p => true).FirstOrDefault();
            user.UserName = "updatename";

            Assert.IsTrue(userDal.UpdateEntity(user));
            Assert.IsTrue(session.SaveChanges()>0);
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
            session.SaveChanges();

            Assert.IsTrue(userDal.DeleteEntity(user));
            Assert.IsTrue(session.SaveChanges() > 0);

            session.DisposeDBContext();
        }

        [TestMethod()]
        public void LoadEntityTest()
        {
          Assert.IsTrue(userDal.LoadEntity(p => true).Count() > 1);
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
