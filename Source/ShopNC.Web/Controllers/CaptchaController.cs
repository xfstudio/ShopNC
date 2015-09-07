using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopNC.Common;
using System.Drawing;

namespace ShopNC.Web.Controllers
{
    public class CaptchaController : Controller
    {
        //
        // GET: /Captcha/
        public void Index()
        {
            //var outstring = string.Empty;
            //var captcha = new FactoryDeal.Jsose.Common.Captcha().GetImage(5, out outstring);

            //#region 验证码
            //Session["Captcha"] = outstring.ToLower();
            //#endregion

            //Response.ClearContent();
            //Response.BinaryWrite(captcha);

            //cts修改只产生数字验证
            var captcha = new ValidateCode();
            string s = captcha.GetRndNum();
            Session["Captcha"] = s.ToLower();
            using (Bitmap img = captcha.CreateImages(s, "ch"))
            {
                Response.ClearContent();
                img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
	}
}