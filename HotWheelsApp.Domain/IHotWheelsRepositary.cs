using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotWheelsApp.Domain
{
    public interface IHotWheelsRepositary
    {
        Task<HotWheel> Add(HotWheel hotWheel);
        Task<HotWheel> Get(int id);
        Task<IEnumerable<HotWheel>> GetAll();
        Task Delete(HotWheel hotWheel);
        Task Put(HotWheel hotWheel);
    }
}
