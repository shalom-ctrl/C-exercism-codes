using System;
using System.Collections.Generic;

// Task 1 & 2: Define the interface that both cars will follow
public interface IRemoteControlCar
{
    void Drive();
    int DistanceTravelled { get; }
}

// Task 3: Implement IComparable to allow sorting by victories
public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    // Comparison logic: returns < 0 (smaller), 0 (equal), or > 0 (larger)
    public int CompareTo(ProductionRemoteControlCar other)
    {
        if (other == null) return 1;
        return this.NumberOfVictories.CompareTo(other.NumberOfVictories);
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        // Because both cars implement IRemoteControlCar, we can call Drive()
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        var cars = new List<ProductionRemoteControlCar> { prc1, prc2 };
        // Sort() uses the CompareTo method we implemented above
        cars.Sort();
        return cars;
    }
}