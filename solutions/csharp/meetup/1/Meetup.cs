using System;
using System.Linq;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly int _month;
    private readonly int _year;

    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        return schedule switch
        {
            Schedule.Teenth => FindDayInRange(13, 19, dayOfWeek),
            Schedule.First  => FindDayInRange(1, 7, dayOfWeek),
            Schedule.Second => FindDayInRange(8, 14, dayOfWeek),
            Schedule.Third  => FindDayInRange(15, 21, dayOfWeek),
            Schedule.Fourth => FindDayInRange(22, 28, dayOfWeek),
            Schedule.Last   => FindLastDay(dayOfWeek),
            _ => throw new ArgumentException("Invalid schedule type")
        };
    }

    private DateTime FindDayInRange(int startDay, int endDay, DayOfWeek dayOfWeek)
    {
        for (int day = startDay; day <= endDay; day++)
        {
            var date = new DateTime(_year, _month, day);
            if (date.DayOfWeek == dayOfWeek)
            {
                return date;
            }
        }
        throw new Exception("Day not found in specified range.");
    }

    private DateTime FindLastDay(DayOfWeek dayOfWeek)
    {
        // Get the last day of the month
        int daysInMonth = DateTime.DaysInMonth(_year, _month);
        
        // Iterate backwards from the end of the month
        for (int day = daysInMonth; day >= 1; day--)
        {
            var date = new DateTime(_year, _month, day);
            if (date.DayOfWeek == dayOfWeek)
            {
                return date;
            }
        }
        throw new Exception("Last day not found.");
    }
}