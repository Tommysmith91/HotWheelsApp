using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotWheels.App.Application
{
    public sealed record HotWheelsEnvelope
    {
        public List<HotWheelDTO> HotWheels { get; init; } = new();
        public int Count { get; set; }
    }
}
