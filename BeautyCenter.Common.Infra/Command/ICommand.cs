using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Infra.Command
{
    public interface ICommand
    {
        Guid CallGuid { get; }
    }
}
