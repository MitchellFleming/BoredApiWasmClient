using System.Text.Json;
using System.Text.Json.Serialization;
using BoredApiClient.Enums;
using BoredApiClient.Models;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace BoredApiClient.DataAccess;

public class BoredDao
{
    private readonly IFlurlClient _flurlClient;

    public BoredDao(IFlurlClientFactory flurlClientFactory)
    {
        _flurlClient = flurlClientFactory.Get("https://www.boredapi.com/api/activity");
    }

    public async Task<ActivityItem> GetRandomActivityAsync(string requestUri = "")
    {
        try
        {
            var response = await _flurlClient.Request().SendAsync(HttpMethod.Get);
            return await response.GetJsonAsync<ActivityItem>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
    
    public async Task<ActivityItem> GetRandomActivityAsync(ActivityRequest request)
    {
        try
        {
            var response = await _flurlClient.Request().SetQueryParams(request.ToDictionary()).SendAsync(HttpMethod.Get);
            return await response.GetJsonAsync<ActivityItem>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<ActivityItem?> GetFilteredActivityAsync(ActivityRequest request)
    {
        var response = await GetRandomActivityAsync(request);
        return !string.IsNullOrWhiteSpace(response.Activity) ? response : null;
    }
}