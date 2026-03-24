using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        // 1. Check if it starts with New York code (212)
        bool isNewYork = phoneNumber.StartsWith("212");

        // 2. Check for the fake prefix (555) at positions 5 to 7
        // In "NNN-NNN-NNNN", index 4 is the '-' and index 5 is the first 'N'
        // String.Substring(startIndex, length)
        bool isFake = phoneNumber.Substring(4, 3) == "555";

        // 3. Get the last 4 digits
        string localNumber = phoneNumber.Substring(8);

        // Return all three as a Tuple
        return (isNewYork, isFake, localNumber);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        // We just need to pull the 'IsFake' boolean out of the tuple we received
        return phoneNumberInfo.IsFake;
    }
}
