using System;
using System.Linq;

public static class Luhn
{
    public static bool IsValid(string number)
    {
        // 1. Remove spaces
        string cleanNumber = number.Replace(" ", "");

        // 2. Length check
        if (cleanNumber.Length <= 1) return false;

        int sum = 0;
        bool shouldDouble = false;

        // 3. Process from right to left
        for (int i = cleanNumber.Length - 1; i >= 0; i--)
        {
            char c = cleanNumber[i];

            // 4. Non-digit check
            if (!char.IsDigit(c)) return false;

            int digit = c - '0';

            if (shouldDouble)
            {
                digit *= 2;
                if (digit > 9) digit -= 9;
            }

            sum += digit;
            shouldDouble = !shouldDouble; // Toggle for every second digit
        }

        // 5. Check if divisible by 10
        return sum % 10 == 0;
    }
}