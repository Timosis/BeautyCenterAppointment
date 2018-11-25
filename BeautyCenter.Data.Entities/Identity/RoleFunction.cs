using BeautyCenter.Common.Infra.DataLayer.Entities;
using BeautyCenter.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.Identity
{
    public class RoleFunction : Entity
    {
        public int RoleId { get; set; }
        public int FunctionId { get; set; }
        public RoleFunctionStatus RoleFunctionStatus { get; set; }

        public Role Role { get; set; }
        public Function Function { get; set; }
    }
}
