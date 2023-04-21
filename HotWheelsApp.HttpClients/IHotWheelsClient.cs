using HotWheels.App.Application;
using HotWheelsApp.Domain;

namespace HotWheelsApp.HttpClients
{
    public interface IHotWheelsClient
    {
        Task<HotWheelsEnvelope> GetAllAsync();
        Task PostASync(HotWheelDTO? hotWheelDTO);
        Task DeleteAsync(int id);
    }
}