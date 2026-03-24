using System;

public class Clock : IEquatable<Clock>
{
    private readonly int _totalMinutes;
    private const int MinutesInDay = 1440;

    public Clock(int hours, int minutes)
    {
        // Convert everything to minutes and wrap around 24 hours
        int total = (hours * 60 + minutes) % MinutesInDay;
        
        // Handle negative results (C# % can return negative)
        if (total < 0) total += MinutesInDay;
        
        _totalMinutes = total;
    }

    public int Hours => _totalMinutes / 60;
    public int Minutes => _totalMinutes % 60;

    public Clock Add(int minutesToAdd) => new Clock(0, _totalMinutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new Clock(0, _totalMinutes - minutesToSubtract);

    // Formatting for debugging and display
    public override string ToString() => $"{Hours:D2}:{Minutes:D2}";

    // Equality implementation
    public bool Equals(Clock other)
    {
        if (other is null) return false;
        return _totalMinutes == other._totalMinutes;
    }

    public override bool Equals(object obj) => Equals(obj as Clock);

    public override int GetHashCode() => _totalMinutes.GetHashCode();
}