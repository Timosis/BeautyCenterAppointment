using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Infra.DataLayer.Entities
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
