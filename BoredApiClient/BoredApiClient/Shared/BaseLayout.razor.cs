using BoredApiClient.Settings;
using BoredApiClient.Theme;
using MudBlazor;

namespace BoredApiClient.Shared;

public partial class BaseLayout
{
    private ClientSetting? _clientSetting;
    private MudTheme _currentTheme = new DarkTheme();
    private bool _themeDrawerOpen;
    private bool _rightToLeft;

    protected override async Task OnInitializedAsync()
    {
        _clientSetting = await ClientThemeManager.GetSettings() as ClientSetting;
        if (_clientSetting == null) _clientSetting = new ClientSetting();
        SetCurrentTheme(_clientSetting);
    }

    private async Task ThemeSettingChanged(ClientSetting themeSetting)
    {
        SetCurrentTheme(themeSetting);
        await ClientThemeManager.SetSetting(themeSetting);
    }

    private void SetCurrentTheme(ClientSetting themeSetting)
    {
        _currentTheme = themeSetting.IsDarkMode ? new DarkTheme() : new LightTheme();
        _currentTheme.Palette.Primary = themeSetting.PrimaryColor;
        _currentTheme.Palette.Secondary = themeSetting.SecondaryColor;
        _currentTheme.LayoutProperties.DefaultBorderRadius = $"{themeSetting.BorderRadius}px";
        _currentTheme.LayoutProperties.DefaultBorderRadius = $"{themeSetting.BorderRadius}px";
    }
}