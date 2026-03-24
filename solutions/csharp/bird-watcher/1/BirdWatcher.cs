using System;

class BirdCount
{
    private readonly int[] _birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        _birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[] { 0, 2, 5, 3, 7, 8, 4 };
    }

    public int Today()
    {
        return _birdsPerDay[_birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        _birdsPerDay[_birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        foreach (int count in _birdsPerDay)
        {
            if (count == 0) return true;
        }
        return false;
    }

    public int CountForFirstDays(int days)
    {
        int total = 0;
        for (int i = 0; i < days; i++)
        {
            total += _birdsPerDay[i];
        }
        return total;
    }

    public int BusyDays()
    {
        int busyCount = 0;
        foreach (int count in _birdsPerDay)
        {
            if (count >= 5) busyCount++;
        }
        return busyCount;
    }
}