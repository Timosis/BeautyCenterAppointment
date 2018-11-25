using BeautyCenter.Common.Infra.DataLayer.Entities;
using BeautyCenter.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.Identity
{
    public class UserRole : Entity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public UserRoleStatus UserRoleStatus { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
