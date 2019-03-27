using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Infra.Command
{
    public abstract class BaseSearchCommand : BaseCommand
    {
        public int PageSize { get; set; }
        public int Skip { get; set; }
        public string SortColumn { get; set; }
        public string SortColumnDir { get; set; }
    }
}
