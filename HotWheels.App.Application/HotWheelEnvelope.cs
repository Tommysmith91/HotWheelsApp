using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotWheels.App.Application
{
    public sealed record HotWheelEnvelope
    {
        public HotWheelDTO HotWheel { get; init; } = new();
    }
    
}
