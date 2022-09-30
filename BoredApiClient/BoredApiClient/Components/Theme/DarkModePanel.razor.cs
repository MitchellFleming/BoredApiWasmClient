using BoredApiClient.Settings;
using Microsoft.AspNetCore.Components;

namespace BoredApiClient.Components.Theme;

public partial class DarkModePanel
{
    private bool _isDarkMode;

    protected override async Task OnInitializedAsync()
    {
        if (await ClientThemeManager.GetSettings() is not ClientSetting themeSetting) themeSetting = new ClientSetting();
        _isDarkMode = themeSetting.IsDarkMode;
    }

    [Parameter]
    public EventCallback<bool> OnIconClicked { get; set; }

    private async Task ToggleDarkMode()
    {
        _isDarkMode = !_isDarkMode;
        await OnIconClicked.InvokeAsync(_isDarkMode);
    }
}