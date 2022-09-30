using System.Text.Json;
using System.Text.Json.Serialization;
using BoredApiClient.Enums;
using BoredApiClient.Models;

namespace BoredApiClient.DataAccess;

public class BoredDao
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public BoredDao()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://www.boredapi.com/api/activity"),
        };
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
    }

    public async Task<ActivityItem> GetRandomActivityAsync(string requestUri = "")
    {
        try
        {
            var response = await _httpClient.GetAsync(requestUri);
            var jsonString = await response.Content.ReadAsStringAsync();
            var returnActivity = JsonSerializer.Deserialize<ActivityItem>(jsonString, _jsonSerializerOptions);
            return returnActivity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<ActivityItem?> GetFilteredActivityAsync(ActivityRequest request)
    {
        var queryString = BuildQueryString(request);
        var response = await GetRandomActivityAsync(queryString);
        return !string.IsNullOrWhiteSpace(response.Activity) ? response : null;
    }

    private static string BuildQueryString(ActivityRequest request)
    {
        // This works for a sample builder, but in a production scenario where the string could change more dynamically a collection of values concatenated with the & as the joining char would be more suitable
        var queryString = "?";
        if (request.Type != ActivityType.Any)
        {
            queryString += $"&type={request.Type}";
        }

        queryString += $"&minAccessibility={request.AccessibilityMin}";
        queryString += $"&maxAccessibility={request.AccessibilityMax}";
        queryString += $"&participants={request.Participants}";
        queryString += $"&minPrice={request.PriceMin}";
        queryString += $"&maxPrice={request.PriceMax}";
        return queryString.ToLower();
    }
}