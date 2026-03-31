using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        // 1. Convert to string to easily access digits and count
        string numberStr = number.ToString();
        int numberOfDigits = numberStr.Length;
        double sum = 0;

        // 2. Iterate through each character (digit)
        foreach (char c in numberStr)
        {
            // Convert char back to its integer value
            int digit = (int)char.GetNumericValue(c);
            
            // 3. Add (digit ^ numberOfDigits) to sum
            sum += Math.Pow(digit, numberOfDigits);
        }

        // 4. Compare sum to the original number
        return sum == (double)number;
    }
}