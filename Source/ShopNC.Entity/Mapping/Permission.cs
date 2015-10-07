using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNC.Entity.Mapping
{
    public class Permission:EntityBase<int>
    {

        [Required,MaxLength(32)]
        public string Name { get; set; }

        [Required, MaxLength(216)]
        public string Path { get; set; }
        public bool? IsMenu { get; set; }

        [MaxLength(32)]
        public string MenuName { get; set; }

        [MaxLength(1024)]
        public string Remark { get; set; }

        public int OrderNum { get; set; }
        public virtual List<PermissionGroup> Groups { get; set; }

        //特殊权限 先从角色 关联 没有才从用户本身关联
        public virtual List<UserInfo> UserInfos { get; set; }
    }
}
