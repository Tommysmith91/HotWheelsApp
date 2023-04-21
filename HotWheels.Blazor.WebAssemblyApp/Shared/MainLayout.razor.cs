using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;

namespace HotWheels.Blazor.WebAssemblyApp.Shared
{
    public partial class MainLayout
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; } = null;

        [CascadingParameter]
        protected Task<AuthenticationState> AuthStat { get; set; }

        protected async override Task OnInitializedAsync()
        {
            base.OnInitialized();
            var user = (await AuthStat).User;
            if (!user.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo($"authentication/login?returnUrl={Uri.EscapeDataString(NavigationManager.Uri)}");
            }
        }
    }
}

