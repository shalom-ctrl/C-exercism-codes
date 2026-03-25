using System;

public static class SwiftScheduling
{
    public static DateTime DeliveryDate(DateTime meetingStart, string description)
    {
        return description switch
        {
            "NOW" => meetingStart.AddHours(2),
            "ASAP" => meetingStart.Hour < 13 
                ? meetingStart.Date.AddHours(17) 
                : meetingStart.Date.AddDays(1).AddHours(13),
            "EOW" => (int)meetingStart.DayOfWeek >= 1 && (int)meetingStart.DayOfWeek <= 3
                ? GetNextWeekday(meetingStart, DayOfWeek.Friday).AddHours(17)
                : GetNextWeekday(meetingStart, DayOfWeek.Sunday).AddHours(20),
            _ => HandleVariableDescription(meetingStart, description)
        };
    }

    private static DateTime HandleVariableDescription(DateTime start, string desc)
    {
        if (desc.EndsWith("M"))
        {
            int n = int.Parse(desc.TrimEnd('M'));
            int year = start.Month < n ? start.Year : start.Year + 1;
            return GetFirstWorkdayOfMonth(year, n).AddHours(8);
        }
        
        if (desc.StartsWith("Q"))
        {
            int q = int.Parse(desc.Substring(1));
            int currentQuarter = (start.Month - 1) / 3 + 1;
            int year = currentQuarter <= q ? start.Year : start.Year + 1;
            return GetLastWorkdayOfQuarter(year, q).AddHours(8);
        }

        throw new ArgumentException("Unknown description format");
    }

    private static DateTime GetFirstWorkdayOfMonth(int year, int month)
    {
        DateTime date = new DateTime(year, month, 1);
        while (IsWeekend(date)) date = date.AddDays(1);
        return date;
    }

    private static DateTime GetLastWorkdayOfQuarter(int year, int quarter)
    {
        int lastMonthOfQuarter = quarter * 3;
        int lastDay = DateTime.DaysInMonth(year, lastMonthOfQuarter);
        DateTime date = new DateTime(year, lastMonthOfQuarter, lastDay);
        while (IsWeekend(date)) date = date.AddDays(-1);
        return date;
    }

    private static DateTime GetNextWeekday(DateTime start, DayOfWeek target)
    {
        int daysUntil = ((int)target - (int)start.DayOfWeek + 7) % 7;
        if (daysUntil == 0 && target != DayOfWeek.Sunday) daysUntil = 0; // Today
        return start.Date.AddDays(daysUntil);
    }

    private static bool IsWeekend(DateTime date) => 
        date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
}