using System.Text.Json;
using System.Text.Json.Serialization;
using BoredApiClient.Enums;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BoredApiClient.Models;

public class ActivityRequest
{
    public ActivityType Type { get; }
    public int Participants { get; }
    public double PriceMin { get; }
    public double PriceMax { get; }
    public double AccessibilityMin { get; }
    public double AccessibilityMax { get; }

    public ActivityRequest(double accessibilityMin, double accessibilityMax, ActivityType type, int participants, double priceMin, double priceMax)
    {
        AccessibilityMin = accessibilityMin;
        AccessibilityMax = accessibilityMax;
        Type = type;
        Participants = participants;
        PriceMin = priceMin;
        PriceMax = priceMax;
    }

    // public Dictionary<string, string> ParseQueryParams()
    // {
    //     var jsonSerializerOptions = new JsonSerializerOptions()
    //     {
    //         DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    //     };
    //
    //     var serializedObject = JsonSerializer.Serialize(this, jsonSerializerOptions);
    //     var result = JsonSerializer.Deserialize<Dictionary<string, string>>(serializedObject);
    //     return result;
    // }
    
    public Dictionary<string, string> ToDictionary()
    {       
        var json = JsonConvert.SerializeObject(this);
        var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);   
        return dictionary;
    }
}