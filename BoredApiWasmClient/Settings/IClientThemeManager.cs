using MudBlazor;

namespace BoredApiWasmClient.Settings;

public interface IClientThemeManager : ISettingManager
{
    Task<MudTheme> GetCurrentThemeAsync();

    Task<bool> ToggleDarkModeAsync();

    Task<bool> ToggleDrawerAsync();

    Task<bool> ToggleLayoutDirectionAsync();
}