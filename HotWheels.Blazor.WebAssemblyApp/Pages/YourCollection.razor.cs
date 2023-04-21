using HotWheels.App.Application;
using HotWheelsApp.Domain;
using HotWheelsApp.HttpClients;
using Microsoft.AspNetCore.Components;

namespace HotWheels.Blazor.WebAssemblyApp.Pages
{
    public partial class YourCollection
    {
        [Inject]
        private IHotWheelsClient _client { get; set; } = null!;
        private List<HotWheelDTO> _hotWheels = new();
        

        protected override async Task OnInitializedAsync()
        {
            var result = await _client.GetAllAsync();
            _hotWheels = result.HotWheels.ToList();
            await base.OnInitializedAsync();
        }
        protected async Task Delete(int Id)
        {
            await _client.DeleteAsync(Id);
            var result = await _client.GetAllAsync();
            _hotWheels = result.HotWheels.ToList();
            await base.OnInitializedAsync();
        }
        
    }
}
