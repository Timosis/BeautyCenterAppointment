using BeautyCenter.Common.Infra.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BeautyCenter.Common.Infra.Command
{
    public abstract class BaseCommand : ICommand
    {
        public int CallerUserId { get; set; }
        public Guid CallGuid => Guid.NewGuid();
        public List<DynamicColumnValueDto> DynamicColumnValues { get; set; }

        [DebuggerStepThrough]
        protected BaseCommand()
        {
            DynamicColumnValues = new List<DynamicColumnValueDto>();
        }

        public abstract string ValidateCommand();
    }
}
