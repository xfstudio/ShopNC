using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNC.Entity.Mapping
{
    [NotMapped]
   public class UserRoleR
    {
       [Key]
        public int ID { get; set; }
        public int UserID { get; set; }

       [ForeignKey("UserID")]
        public virtual UserInfo UserInfo { get; set; }

       public int RoleID { get; set; }

       [ForeignKey("RoleID")]
       public virtual UserRole UserRole { get; set; }
    }
}
