using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNC.IService.Cond
{
    public class UserInfoCond : PageListBaseCond
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
