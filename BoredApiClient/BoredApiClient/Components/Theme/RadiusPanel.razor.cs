using BoredApiClient.Settings;
using Microsoft.AspNetCore.Components;

namespace BoredApiClient.Components.Theme;

public partial class RadiusPanel
{
    [Parameter]
    public double Radius { get; set; }

    [Parameter]
    public double MaxValue { get; set; } = 30;

    [Parameter]
    public EventCallback<double> OnSliderChanged { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (await ClientThemeManager.GetSettings() is not ClientSetting themeSetting) themeSetting = new ClientSetting();
        Radius = themeSetting.BorderRadius;
    }

    private async Task ChangedSelection(ChangeEventArgs args)
    {
        Radius = int.Parse(args?.Value?.ToString() ?? "0");
        await OnSliderChanged.InvokeAsync(Radius);
    }
}