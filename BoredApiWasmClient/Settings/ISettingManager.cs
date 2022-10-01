namespace BoredApiWasmClient.Settings;

public interface ISettingManager
{
    Task SetSetting(ISetting setting);

    Task<ISetting> GetSettings();
}