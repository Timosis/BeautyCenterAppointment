using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Types.Dto.Installment
{
    public class InstallmentDto
    {

        public int Id { get; set; }

        public DateTime InstallmentDate { get; set; }

        public bool IsPaid { get; set; }

        public double TotalAmount { get; set; }

        public List<InstallmentDetailDto> InstallmentDetails { get; set; }
    }
}
