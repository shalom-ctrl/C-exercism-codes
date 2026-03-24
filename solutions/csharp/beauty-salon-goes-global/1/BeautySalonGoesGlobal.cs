using System;
using System.Globalization;
using System.Runtime.InteropServices;

public enum Location { NewYork, London, Paris }
public enum AlertLevel { Early, Standard, Late }

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime localTime = DateTime.Parse(appointmentDateDescription);
        string tzId = GetTimeZoneId(location);
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(tzId);
        
        // Convert the local time of the salon to UTC
        return TimeZoneInfo.ConvertTimeToUtc(localTime, tz);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddHours(-1).AddMinutes(-45),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => throw new ArgumentOutOfRangeException(nameof(alertLevel))
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneId(location));
        
        // Check if DST status changed between 7 days ago and the current date
        bool nowDst = tz.IsDaylightSavingTime(dt);
        bool thenDst = tz.IsDaylightSavingTime(dt.AddDays(-7));
        
        return nowDst != thenDst;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        // Select the culture based on the location
        string cultureName = location switch
        {
            Location.NewYork => "en-US",
            Location.London => "en-GB",
            Location.Paris => "fr-FR",
            _ => "en-US"
        };

        if (DateTime.TryParse(dtStr, new CultureInfo(cultureName), DateTimeStyles.None, out DateTime result))
        {
            return result;
        }

        return new DateTime(1, 1, 1);
    }

    private static string GetTimeZoneId(Location location)
    {
        bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        return location switch
        {
            Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
            Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
            Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
            _ => throw new ArgumentOutOfRangeException(nameof(location))
        };
    }
}