namespace BoredApiClient.Settings;

public interface ISettingManager
{
    Task SetSetting(ISetting setting);

    Task<ISetting> GetSettings();
}