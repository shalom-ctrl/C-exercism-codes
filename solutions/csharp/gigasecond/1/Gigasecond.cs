using System;

public static class Gigasecond
{
    // A gigasecond is 10^9 seconds
    private const double GigasecondValue = 1_000_000_000.0;

    public static DateTime Add(DateTime moment)
    {
        // DateTime.AddSeconds returns a new DateTime 
        // representing the original moment plus the offset
        return moment.AddSeconds(GigasecondValue);
    }
}