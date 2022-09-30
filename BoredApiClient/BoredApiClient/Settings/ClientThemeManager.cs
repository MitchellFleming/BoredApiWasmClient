using System.Text.RegularExpressions;
using Blazored.LocalStorage;
using BoredApiClient.Theme;
using MudBlazor;

namespace BoredApiClient.Settings;

public class ClientThemeManager : IClientThemeManager
{
    private readonly ILocalStorageService _localStorageService;

    public ClientThemeManager(
        ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<bool> ToggleDarkModeAsync()
    {
        if (await GetSettings() is ClientSetting setting)
        {
            setting.IsDarkMode = !setting.IsDarkMode;
            await SetSetting(setting);
            return !setting.IsDarkMode;
        }

        return false;
    }

    public async Task<bool> ToggleDrawerAsync()
    {
        if (await GetSettings() is ClientSetting settings)
        {
            settings.IsDrawerOpen = !settings.IsDrawerOpen;
            await SetSetting(settings);
            return settings.IsDrawerOpen;
        }

        return false;
    }

    public async Task<bool> ToggleLayoutDirectionAsync()
    {
        if (await GetSettings() is ClientSetting setting)
        {
            await SetSetting(setting);
            return true;
        }
    
        return false;
    }

    public async Task<MudTheme> GetCurrentThemeAsync()
    {
        if (await GetSettings() is ClientSetting setting)
        {
            if (setting.IsDarkMode) return new DarkTheme();
        }

        return new LightTheme();
    }

    public async Task<string> GetPrimaryColorAsync()
    {
        if (await GetSettings() is ClientSetting setting)
        {
            string colorCode = setting.PrimaryColor;
            if (Regex.Match(colorCode, "^#(?:[0-9a-fA-F]{3,4}){1,2}$").Success)
            {
                return colorCode;
            }
            else
            {
                setting.PrimaryColor = CustomColors.Light.Primary;
                await SetSetting(setting);
                return setting.PrimaryColor;
            }
        }

        return CustomColors.Light.Primary;
    }

    public async Task<bool> IsDrawerOpen()
    {
        if (await GetSettings() is ClientSetting setting)
        {
            return setting.IsDrawerOpen;
        }

        return false;
    }

    public static string Setting = "clientSetting";

    public async Task<ISetting> GetSettings()
    {
        return await _localStorageService.GetItemAsync<ClientSetting>(Setting) ?? new ClientSetting();
    }

    public async Task SetSetting(ISetting setting)
    {
        await _localStorageService.SetItemAsync(Setting, setting as ClientSetting);
    }
}