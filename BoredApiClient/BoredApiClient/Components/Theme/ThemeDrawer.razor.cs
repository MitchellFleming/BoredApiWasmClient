using BoredApiClient.Settings;
using BoredApiClient.Theme;
using Microsoft.AspNetCore.Components;

namespace BoredApiClient.Components.Theme;

public partial class ThemeDrawer
{
    [Parameter]
    public bool ThemeDrawerOpen { get; set; }

    [Parameter]
    public EventCallback<bool> ThemeDrawerOpenChanged { get; set; }

    [EditorRequired]
    [Parameter]
    public ClientSetting ThemeSetting { get; set; } = default!;

    [EditorRequired]
    [Parameter]
    public EventCallback<ClientSetting> ThemeSettingChanged { get; set; }

    private readonly List<string> _colors = CustomColors.ThemeColors;

    private async Task UpdateThemePrimaryColor(string color)
    {
        if (ThemeSetting is not null)
        {
            ThemeSetting.PrimaryColor = color;
            await ThemeSettingChanged.InvokeAsync(ThemeSetting);
        }
    }

    private async Task UpdateThemeSecondaryColor(string color)
    {
        if (ThemeSetting is not null)
        {
            ThemeSetting.SecondaryColor = color;
            await ThemeSettingChanged.InvokeAsync(ThemeSetting);
        }
    }

    private async Task UpdateBorderRadius(double radius)
    {
        if (ThemeSetting is not null)
        {
            ThemeSetting.BorderRadius = radius;
            await ThemeSettingChanged.InvokeAsync(ThemeSetting);
        }
    }

    private async Task ToggleDarkLightMode(bool isDarkMode)
    {
        if (ThemeSetting is not null)
        {
            ThemeSetting.IsDarkMode = isDarkMode;
            await ThemeSettingChanged.InvokeAsync(ThemeSetting);
        }
    }
}