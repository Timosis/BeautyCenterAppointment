using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Infra.Types
{
    public class DynamicColumnValueDto
    {
        public int Id { get; set; }
        public int DynamicColumnId { get; set; }
        public int ExtendedObjectId { get; set; }
        public int DataId { get; set; }
        public int? IntValue { get; set; }
        public string StringValue { get; set; }
        public long? LongValue { get; set; }
        public byte[] BinaryValue { get; set; }
        public DateTime? DateTimeValue { get; set; }
        public byte? ByteValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public bool? BoolValue { get; set; }
    }
}
