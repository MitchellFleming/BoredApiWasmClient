using System.Globalization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BoredApiClient;
using BoredApiClient.DataAccess;
using BoredApiClient.Settings;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddBlazoredLocalStorage()
    .AddScoped<BoredDao>()
    .AddMudServices(configuration =>
    {
        configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
        configuration.SnackbarConfiguration.HideTransitionDuration = 125;
        configuration.SnackbarConfiguration.ShowTransitionDuration = 125;
        configuration.SnackbarConfiguration.VisibleStateDuration = 3500;
        configuration.SnackbarConfiguration.ShowCloseIcon = false;
    })
    .AddScoped<IClientThemeManager, ClientThemeManager>();

var host = builder.Build();

var storageService = host.Services.GetRequiredService<IClientThemeManager>();
if (storageService != null)
{
    var culture = new CultureInfo("en-US");
    CultureInfo.DefaultThreadCurrentCulture = culture;
    CultureInfo.DefaultThreadCurrentUICulture = culture;
}

await host.RunAsync();