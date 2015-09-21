using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNC.Entity.Mapping
{
    public class PermissionGroup:EntityBase<int>
    {
        [Required,MaxLength(32)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string Remark { get; set; }

        public int OrderNum { get; set; }
        public virtual IList<Permission> Permissions { get; set; }

        public virtual List<UserRole> Roles { get; set; }
    }
}
