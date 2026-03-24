using System;

class WeighingMachine
{
    // Task 1: Get-only property set via constructor
    public int Precision { get; }

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    // Task 2 & 3: Weight with validation (needs a backing field)
    private double _weight;
    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Weight cannot be negative.");
            }
            _weight = value;
        }
    }

    // Task 4 & 5: Tare adjustment with a default value of 5.0
    public double TareAdjustment { get; set; } = 5.0;

    // Task 6: Calculated display weight property
    public string DisplayWeight
    {
        get
        {
            // Calculation: input-weight - tare-adjustment
            double adjustedWeight = Weight - TareAdjustment;
            
            // Format the number to the specified precision
            // "F" followed by the precision number (e.g., "F3") formats to decimals
            return $"{adjustedWeight.ToString("F" + Precision)} kg";
        }
    }
}