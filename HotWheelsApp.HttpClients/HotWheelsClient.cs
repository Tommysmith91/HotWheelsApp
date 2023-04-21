using HotWheels.App.Application;
using HotWheelsApp.Domain;
using System.Net.Http.Json;

namespace HotWheelsApp.HttpClients
{
    public class HotWheelsClient : IHotWheelsClient
    {
        private readonly HttpClient _httpClient;

        public HotWheelsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HotWheelsEnvelope> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<HotWheelsEnvelope>("HotWheels") ?? new();
            return response;
        }
        public async Task PostASync(HotWheelDTO? hotWheelDTO)
        {            
            var _ = await _httpClient.PostAsJsonAsync("HotWheels", hotWheelDTO);            
        }
        public async Task DeleteAsync(int id)
        {
            if(id == 0)
            {
                return;
            }
            var response = await _httpClient.DeleteAsync($"HotWheels/{id}");            
        }

        
    }
}