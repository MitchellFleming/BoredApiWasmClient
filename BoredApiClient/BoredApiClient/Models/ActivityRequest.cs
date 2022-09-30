using BoredApiClient.Enums;

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
}