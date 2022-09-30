using BoredApiClient.Settings;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BoredApiClient.Shared;

public partial class MainLayout
{
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    [Parameter]
    public EventCallback OnDarkModeToggle { get; set; }

    [Parameter]
    public EventCallback<bool> OnRightToLeftToggle { get; set; }

    private bool _drawerOpen;
    private bool _rightToLeft;

    protected override async Task OnInitializedAsync()
    {
        if (await ClientThemeManager.GetSettings() is ClientSetting preference)
        {
            _drawerOpen = preference.IsDrawerOpen;
        }
    }

    private async Task RightToLeftToggle()
    {
        bool isRtl = await ClientThemeManager.ToggleLayoutDirectionAsync();
        _rightToLeft = isRtl;

        await OnRightToLeftToggle.InvokeAsync(isRtl);
    }

    public async Task ToggleDarkMode()
    {
        await OnDarkModeToggle.InvokeAsync();
    }

    private async Task DrawerToggle()
    {
        _drawerOpen = await ClientThemeManager.ToggleDrawerAsync();
    }
}