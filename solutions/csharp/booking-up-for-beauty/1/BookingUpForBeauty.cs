using System;

static class Appointment
{
    // Task 1: Convert the input string into a DateTime object
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription);
    }

    // Task 2: Check if the appointment date is in the past compared to right now
    public static bool HasPassed(DateTime appointmentDate)
    {
        return appointmentDate < DateTime.Now;
    }

    // Task 3: Check if the time is between 12:00 (inclusive) and 18:00 (exclusive)
    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        return appointmentDate.Hour >= 12 && appointmentDate.Hour < 18;
    }

    // Task 4: Format a friendly description string
    public static string Description(DateTime appointmentDate)
    {
        // This will naturally format to "3/29/2019 3:00:00 PM" in en-US culture
        return $"You have an appointment on {appointmentDate}.";
    }

    // Task 5: Return September 15th for the current calendar year
    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Now.Year, 9, 15);
    }
}