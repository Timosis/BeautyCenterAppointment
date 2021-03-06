﻿using BeautyCenter.Common.Infra.DataLayer.Entities;
using BeautyCenter.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.Identity
{
    public class Function : Entity
    {
        public string Name { get; set; }
        public string UniqueName { get; set; }
        public string Description { get; set; }
        public FunctionStatus FunctionStatus { get; set; }

        public List<RoleFunction> RoleFunctions { get; set; }
    }
}
