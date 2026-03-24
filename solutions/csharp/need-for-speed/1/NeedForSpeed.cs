using System;

class RemoteControlCar
{
    private int speed;
    private int batteryDrain;
    private int distanceDriven = 0;
    private int batteryRemaining = 100;

    // Task 1: Constructor for the car
    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    // Task 3 & 4: Return current status
    public bool BatteryDrained() => batteryRemaining < batteryDrain;

    public int DistanceDriven() => distanceDriven;

    // Task 3 & 4: Update state when driving
    public void Drive()
    {
        if (!BatteryDrained())
        {
            distanceDriven += speed;
            batteryRemaining -= batteryDrain;
        }
    }

    // Task 5: Static factory method for the Nitro car
    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }

    // Helper properties for the RaceTrack to access car specs
    public int Speed => speed;
    public int BatteryDrain => batteryDrain;
}

class RaceTrack
{
    private int distance;

    // Task 2: Constructor for the track
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    // Task 6: Check if a car can finish
    public bool TryFinishTrack(RemoteControlCar car)
    {
        // A car can finish if (Distance / Speed) * BatteryDrain <= 100
        // We calculate how many times the car needs to drive to cover the distance
        int totalDrivesNeeded = (int)Math.Ceiling((double)distance / car.Speed);
        int totalBatteryNeeded = totalDrivesNeeded * car.BatteryDrain;
        
        return totalBatteryNeeded <= 100;
    }
}