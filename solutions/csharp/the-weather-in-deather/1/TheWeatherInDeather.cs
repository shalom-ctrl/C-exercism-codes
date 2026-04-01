using System;
using System.Collections.Generic;

// 1. Weather Station logic using Expression-Bodied Members
public class WeatherStation
{
    private Reading reading;
    private List<DateTime> recordDates = new List<DateTime>();
    private List<decimal> temperatures = new List<decimal>();

    public void AcceptReading(Reading reading)
    {
        this.reading = reading;
        recordDates.Add(DateTime.Now);
        temperatures.Add(reading.Temperature);
    }

    public void ClearAll()
    {
        reading = new Reading();
        recordDates.Clear();
        temperatures.Clear();
    }

    public decimal LatestTemperature => reading.Temperature;
    public decimal LatestPressure => reading.Pressure;
    public decimal LatestRainfall => reading.Rainfall;

    public bool HasHistory => recordDates.Count > 1;

    public Outlook ShortTermOutlook =>
        reading.Equals(new Reading())
            ? throw new ArgumentException()
            : reading switch
            {
                _ when reading.Pressure < 10m && reading.Temperature < 30m => Outlook.Cool,
                _ when reading.Temperature > 50m => Outlook.Good,
                _ => Outlook.Warm
            };

    public Outlook LongTermOutlook => reading.WindDirection switch
    {
        WindDirection.Southerly => Outlook.Good,
        WindDirection.Easterly when reading.Temperature > 20 => Outlook.Good,
        WindDirection.Northerly => Outlook.Cool,
        WindDirection.Easterly when reading.Temperature <= 20 => Outlook.Warm,
        WindDirection.Westerly => Outlook.Rainy,
        _ => throw new ArgumentException()
    };

    public State RunSelfTest() => reading.Equals(new Reading()) ? State.Bad : State.Good;
}

// 2. The Reading Struct (Must be accessible to WeatherStation)
public struct Reading
{
    public decimal Temperature { get; }
    public decimal Pressure { get; }
    public decimal Rainfall { get; }
    public WindDirection WindDirection { get; }

    public Reading(decimal temperature, decimal pressure,
        decimal rainfall, WindDirection windDirection)
    {
        Temperature = temperature;
        Pressure = pressure;
        Rainfall = rainfall;
        WindDirection = windDirection;
    }
}

// 3. Supporting Enums
public enum State { Good, Bad }

public enum Outlook { Cool, Rainy, Warm, Good }

public enum WindDirection
{
    Unknown,
    Northerly,
    Easterly,
    Southerly,
    Westerly
}