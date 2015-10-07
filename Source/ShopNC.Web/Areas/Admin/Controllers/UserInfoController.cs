using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopNC.IService;
using ShopNC.IService.Cond;
using Newtonsoft.Json;

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
            var data =await userBll.GetPageUserInfo(cond);
            var result = new { total = cond.TotalRecord, rows =data };
            return Json(result);
            
        }
	}
}