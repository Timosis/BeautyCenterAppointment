using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Infra.DataLayer.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }
        int CreatedBy { get; set; }
        int ModifiedBy { get; set; }
    }
}
