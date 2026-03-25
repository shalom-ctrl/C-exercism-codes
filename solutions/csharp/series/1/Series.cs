using System;
using System.Collections.Generic;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        // Validation Rules
        if (sliceLength <= 0) 
            throw new ArgumentException("Slice length must be greater than 0.");
        
        if (sliceLength > numbers.Length) 
            throw new ArgumentException("Slice length cannot be greater than the string length.");

        if (string.IsNullOrEmpty(numbers))
            throw new ArgumentException("Series cannot be empty.");

        int numberOfSlices = numbers.Length - sliceLength + 1;
        string[] result = new string[numberOfSlices];

        for (int i = 0; i < numberOfSlices; i++)
        {
            result[i] = numbers.Substring(i, sliceLength);
        }

        return result;
    }
}