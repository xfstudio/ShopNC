using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopNC.IService;
using ShopNC.IService.Cond;
using Newtonsoft.Json;
using ShopNC.Entity.Mapping;
using ShopNC.Common;
using System.Linq.Expressions;

namespace ShopNC.Web.Areas.Admin.Controllers
{
    public class UserInfoController : BaseController
    {
        IUserInfoService userBll;
        public UserInfoController(IUserInfoService bll)
        {
            this.userBll = bll;
        }
        //
        // GET: /Admin/AdminUser/
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetPageUserInfo(UserInfoCond cond)
        {
            Expression<Func<UserInfo, bool>> whereLambda = p => true;
            if (!string.IsNullOrWhiteSpace(cond.UserName))
            {
                whereLambda = whereLambda.And(p => p.UserName.Contains(cond.UserName));
            }
            if (!string.IsNullOrWhiteSpace(cond.Email))
            {
                whereLambda = whereLambda.And<UserInfo>(p => p.Email.Contains(cond.Email));
            }

           // var data =await userBll.GetPageUserInfo(cond);
            int count=0;
            var data = await userBll.LoadPageEntityAsync(whereLambda, cond.Page, cond.Rows,out count, p => p.CreateTime, false);
            var result = new { total = cond.TotalRecord, rows =data };
            return Json(result);
            
        }
	}
}