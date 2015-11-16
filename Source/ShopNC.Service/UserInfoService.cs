using ShopNC.Entity.Mapping;
using ShopNC.IRepository;
using ShopNC.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNC.Service
{
    public partial class UserInfoService:BaseService<UserInfo>, IUserInfoService
    {
        public async Task<IQueryable<UserInfo>> GetPageUserInfo(IService.Cond.UserInfoCond cond)
        {
           int total = cond.TotalRecord;
           var data= await LoadPageEntityAsync(p => true, cond.Page, cond.Rows,out total, p => p.CreateTime, false);
           cond.TotalRecord = total;
           return data;
        }
    }
}
