using System;
using System.Collections.Generic;
using System.Linq;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        var result = new List<uint>();

        foreach (var number in numbers)
        {
            var bytes = new List<uint>();
            uint temp = number;

            // Handle 0 as a special case
            if (temp == 0) bytes.Add(0);

            while (temp > 0)
            {
                // Extract 7 bits
                uint sevenBits = temp & 0x7F;
                
                // Set the 8th bit for all bytes except the first one we process
                // (which will eventually be the LAST byte in the sequence)
                if (bytes.Count > 0) sevenBits |= 0x80;
                
                bytes.Add(sevenBits);
                temp >>= 7;
            }

            // The bytes were added small-to-large, so we reverse them
            bytes.Reverse();
            result.AddRange(bytes);
        }

        return result.ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        var result = new List<uint>();
        uint accumulator = 0;
        bool completed = false;

        for (int i = 0; i < bytes.Length; i++)
        {
            uint b = bytes[i];
            
            // Shift current value to make room for 7 new bits
            accumulator = (accumulator << 7) | (b & 0x7F);

            // Check if MSB (bit 7) is clear
            if ((b & 0x80) == 0)
            {
                result.Add(accumulator);
                accumulator = 0;
                completed = true;
            }
            else
            {
                completed = false;
            }
        }

        if (!completed)
        {
            throw new InvalidOperationException("Incomplete VLQ sequence.");
        }

        return result.ToArray();
    }
}