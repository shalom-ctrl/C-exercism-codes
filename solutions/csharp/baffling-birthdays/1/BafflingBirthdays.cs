using System;
using System.Collections.Generic;
using System.Linq;

public static class BafflingBirthdays
{
    private static readonly Random _random = new Random();

    public static DateOnly[] RandomBirthdates(int numberOfBirthdays)
    {
        var dates = new DateOnly[numberOfBirthdays];
        for (int i = 0; i < numberOfBirthdays; i++)
        {
            // Using 2023 because it is not a leap year
            int dayOfYear = _random.Next(1, 366);
            dates[i] = new DateOnly(2023, 1, 1).AddDays(dayOfYear - 1);
        }
        return dates;
    }

    public static bool SharedBirthday(DateOnly[] birthdays)
    {
        // We only care about Month and Day, so we use a HashSet of tuples
        var seen = new HashSet<(int Month, int Day)>();
        
        foreach (var date in birthdays)
        {
            if (!seen.Add((date.Month, date.Day)))
            {
                return true; // Duplicate found!
            }
        }
        return false;
    }
    
   public static double EstimatedProbabilityOfSharedBirthday(int numberOfBirthdays)
{
    const int trials = 10000;
    int sharedCount = 0;

    for (int i = 0; i < trials; i++)
    {
        var birthdays = RandomBirthdates(numberOfBirthdays);
        if (SharedBirthday(birthdays))
        {
            sharedCount++;
        }
    }

    // Multiply by 100 to convert the fraction (0.50) to a percentage (50.0)
    return ((double)sharedCount / trials) * 100;
}
}