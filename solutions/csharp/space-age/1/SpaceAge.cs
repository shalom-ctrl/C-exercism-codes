using System;

public class SpaceAge
{
    private readonly int _seconds;
    private const double EarthYearInSeconds = 31557600.0;

    public SpaceAge(int seconds)
    {
        _seconds = seconds;
    }

    private double CalculateAge(double orbitalPeriodInEarthYears)
    {
        // Age = Total Seconds / (Seconds in an Earth Year * Planet's Orbital Period)
        return _seconds / (EarthYearInSeconds * orbitalPeriodInEarthYears);
    }

    public double OnEarth() => CalculateAge(1.0);

    public double OnMercury() => CalculateAge(0.2408467);

    public double OnVenus() => CalculateAge(0.61519726);

    public double OnMars() => CalculateAge(1.8808158);

    public double OnJupiter() => CalculateAge(11.862615);

    public double OnSaturn() => CalculateAge(29.447498);

    public double OnUranus() => CalculateAge(84.016846);

    public double OnNeptune() => CalculateAge(164.79132);
}