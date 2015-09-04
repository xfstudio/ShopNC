using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNC.Entity.Mapping
{
    public class UserRole:EntityBase<int>
    {
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ID { get; set; }

        [MaxLength(16),Required]
        public string ENName { get; set; }
       
        [MaxLength(16)]
        public string CNName { get; set; }

        [MaxLength(1024)]
        public string Remark { get; set; }

        public byte Status { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? EditeTime { get; set; }

        [MaxLength(16)]
        public string Editor { get; set; }

        //[InverseProperty("UserRole")]//属性反转
        //public List<UserRoleR> UserRoleR { get; set; }

        public virtual List<UserInfo> UserInfos { get; set; }
    }
}
