using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using BoredApiClient.Enums;

namespace BoredApiClient.Models;

[DataContract]
public class ActivityItem
{
    [JsonPropertyName("activity")]
    [MinLength(1)]
    public string Activity { get; }

    [JsonPropertyName("accessibility")]
    [Range(0.00, 1.00)]
    public double Accessibility { get; }

    [JsonPropertyName("type")]
    public ActivityType Type { get; }

    [JsonPropertyName("participants")]
    [Range(1, int.MaxValue)]
    public int Participants { get; }

    [JsonPropertyName("price")]
    [Range(0.00, 1.00)]
    public double Price { get; }

    [JsonPropertyName("link")]
    [Url]
    public string Link { get; }

    [JsonPropertyName("key")]
    [Range(1000000, 9999999)]
    public string Key { get; }

    public ActivityItem(string activity, double accessibility, ActivityType type, int participants, double price, string link, string key)
    {
        Activity = activity;
        Accessibility = accessibility;
        Type = type;
        Participants = participants;
        Price = price;
        Link = link;
        Key = key;
    }
}