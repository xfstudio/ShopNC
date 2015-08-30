using ShopNC.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ShopNC.Repository
{
    public partial class DBSession:IDBSession
    {

        private IUserInfoRepository _UserInfoRepository;
        public  IUserInfoRepository  UserInfoRepository
        {
            get 
            {
                if (_UserInfoRepository == null)
                {
                   _UserInfoRepository=new UserInfoRepository();
                }

                return _UserInfoRepository;
            }
        }


        private IUserRoleRepository _UserRoleRepository;
        public  IUserRoleRepository  UserRoleRepository
        {
            get 
            {
                if (_UserRoleRepository == null)
                {
                   _UserRoleRepository=new UserRoleRepository();
                }

                return _UserRoleRepository;
            }
        }

    }
}

