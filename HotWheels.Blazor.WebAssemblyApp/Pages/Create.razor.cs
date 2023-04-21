using HotWheels.App.Application;
using HotWheelsApp.HttpClients;
using Microsoft.AspNetCore.Components;

namespace HotWheels.Blazor.WebAssemblyApp.Pages
{
    public partial class Create
    {
        [Inject]
        private IHotWheelsClient _client { get; set; } = null!;
        [Inject]
        private NavigationManager _navManager { get; set; } = null!;

        private HotWheelDTO _hotWheel { get; set; } = new HotWheelDTO();

        private async void HandleValidSubmit()
        {
            await _client.PostASync(_hotWheel);

            _navManager.NavigateTo("/yourcollection");
        }

    }


}
