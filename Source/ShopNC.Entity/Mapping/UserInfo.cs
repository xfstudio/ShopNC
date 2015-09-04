using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNC.Entity.Mapping
{
    public class UserInfo : EntityBase<int>
    {
        //[Key]
        //public int ID { get; set; }

        [MaxLength(16), Required]
        public string UserName { get; set; }

        [MaxLength(8)]
        public string TrueName { get; set; }

        [MaxLength(16), Required]
        public string Password { get; set; }

        [MaxLength(32)]
        public string Email { get; set; }

        [MaxLength(11)]
        public string Phone { get; set; }

        [MaxLength(32)]
        public string TelePhone { get; set; }

        [MaxLength(64)]
        public string Address { get; set; }

        public byte Gender { get; set; }

        public byte Status { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? EditeTime { get; set; }

        [MaxLength(16)]
        public string Editor { get; set; }

       //public List<UserRoleR> UserRoleR { get; set; }
       public List<UserRole> Roles { get; set; }
    }
}
