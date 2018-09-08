using System;
using System.Collections.Generic;
using System.Text;

namespace Qss.Base.Models
{
    public interface ICreateTimestamp
    {
        DateTimeOffset CreateTimestamp { get; set; }
    }
}
