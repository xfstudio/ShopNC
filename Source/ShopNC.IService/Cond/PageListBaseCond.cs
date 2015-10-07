using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNC.IService.Cond
{
    public class PageListBaseCond
    {
        /// <summary>
        /// 页索引
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        public int Rows { get; set; }

        public int TotalRecord { get; set; }
    }
}
