using System;
using System.Collections.Generic;
using System.Linq;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        // 1. Validation
        if (inputBase < 2) throw new ArgumentException("Input base must be at least 2.");
        if (outputBase < 2) throw new ArgumentException("Output base must be at least 2.");
        if (inputDigits.Any(d => d < 0 || d >= inputBase)) 
            throw new ArgumentException("Invalid input digit.");

        // 2. Convert Input Base -> Decimal (Base 10)
        int decimalValue = 0;
        foreach (int digit in inputDigits)
        {
            decimalValue = decimalValue * inputBase + digit;
        }

        // Handle the case where the input is just [0]
        if (decimalValue == 0) return new[] { 0 };

        // 3. Convert Decimal -> Output Base
        var resultDigits = new List<int>();
        while (decimalValue > 0)
        {
            resultDigits.Add(decimalValue % outputBase);
            decimalValue /= outputBase;
        }

        // 4. Reverse to get correct positional order
        resultDigits.Reverse();
        return resultDigits.ToArray();
    }
}