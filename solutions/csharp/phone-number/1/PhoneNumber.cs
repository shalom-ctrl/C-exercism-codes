using System;
using System.Linq;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        // 1. Keep only the digits
        string digits = new string(phoneNumber.Where(char.IsDigit).ToArray());

        // 2. Handle length and Country Code
        if (digits.Length == 11)
        {
            if (digits[0] != '1') 
                throw new ArgumentException("11-digit numbers must start with 1.");
            
            digits = digits.Substring(1); // Strip the '1'
        }

        if (digits.Length != 10)
            throw new ArgumentException("Number must be 10 digits (or 11 with country code).");

        // 3. Validate NANP NXX-NXX-XXXX structure
        // Area code (index 0) and Exchange code (index 3) cannot start with 0 or 1
        if (digits[0] < '2') 
            throw new ArgumentException("Area code cannot start with 0 or 1.");
        
        if (digits[3] < '2') 
            throw new ArgumentException("Exchange code cannot start with 0 or 1.");

        return digits;
    }
}