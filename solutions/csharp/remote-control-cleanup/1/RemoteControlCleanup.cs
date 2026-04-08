using System;

public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }
    private Speed currentSpeed;

    // The property remains named 'Telemetry' for the API requirements
    public TelemetryPanel Telemetry { get; }

    public RemoteControlCar()
    {
        // We pass 'this' so the nested class can control this specific car
        Telemetry = new TelemetryPanel(this);
    }

    public string GetSpeed() => currentSpeed.ToString();

    private void SetSponsor(string sponsorName) => CurrentSponsor = sponsorName;

    private void SetSpeed(Speed speed) => currentSpeed = speed;

    // Renamed the class to TelemetryPanel to avoid the CS0102 name collision
    public class TelemetryPanel
    {
        private readonly RemoteControlCar _car;

        internal TelemetryPanel(RemoteControlCar car) => _car = car;

        public void Calibrate() { /* ... */ }

        public bool SelfTest() => true;

        public void ShowSponsor(string sponsorName) => _car.SetSponsor(sponsorName);

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = unitsString == "cps" 
                ? SpeedUnits.CentimetersPerSecond 
                : SpeedUnits.MetersPerSecond;

            _car.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    private enum SpeedUnits { MetersPerSecond, CentimetersPerSecond }

    private struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits Units { get; }
        public Speed(decimal amount, SpeedUnits units) { Amount = amount; Units = units; }
        public override string ToString() => 
            $"{Amount} {(Units == SpeedUnits.CentimetersPerSecond ? "centimeters per second" : "meters per second")}";
    }
}