class RemoteControlCar
{
    private int _distanceDriven = 0;
    private int _batteryLevel = 100;
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distanceDriven} meters";
    }

    public string BatteryDisplay()
    {
        if (_batteryLevel == 0)
        {
            return "Battery empty";
        }
        return $"Battery at {_batteryLevel}%";
    }

    public void Drive()
    {
        if (_batteryLevel > 0)
        {
            _distanceDriven += 20; 
            _batteryLevel -= 1; 
        }
    }
}