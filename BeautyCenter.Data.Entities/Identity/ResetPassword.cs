using BeautyCenter.Common.Infra.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.Identity
{
    public class ResetPassword : Entity
    {
        public int UserId { get; set; }
        public string UniqueId { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime? UsedDate { get; set; }

        public User User { get; set; }
    }
}
