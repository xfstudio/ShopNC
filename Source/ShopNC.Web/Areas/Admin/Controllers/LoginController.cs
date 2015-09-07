using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopNC.IService;
using ShopNC.Service;
using ShopNC.Entity.Mapping;

namespace ShopNC.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        IUserInfoService bll;

        public LoginController(IUserInfoService bll) 
        {
            this.bll = bll;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserInfo user, FormCollection form)
        {
            string captcha = Request.Form["captcha"];
            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(captcha))
            {
                return JavaScript("alert('必填项未填写！');");
            }
            if (null != Session["Captcha"] && captcha.ToLower() != Session["Captcha"].ToString().ToLower())
            {
                return JavaScript("alert('验证码错误！');");
            }

            string pwd = Common.MD5Encode.MD5(user.Password);
            user = this.bll.LoadEntity(p => user.UserName == p.UserName && pwd == p.Password).FirstOrDefault();

            if (user == null)
            {
                return JavaScript("alert('用户名密码错误！')");
            }

            Session["Admin"] = user;
            return JavaScript("window.location.href='/Admin/Home'");
        }
    }
}