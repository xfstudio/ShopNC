using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopNC.IRepository;
namespace ShopNC.IRepository
{
    public partial interface IDBSession
    {
    IUserInfoRepository UserInfoRepository{ get;}

    IUserRoleRepository UserRoleRepository{ get;}

    }
}
