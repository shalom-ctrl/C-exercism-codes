using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        // 1. Validation: Hamming distance is only defined for equal lengths
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException("Strands must be of equal length.");
        }

        int distance = 0;

        // 2. Iterate through the strands and count differences
        for (int i = 0; i < firstStrand.Length; i++)
        {
            if (firstStrand[i] != secondStrand[i])
            {
                distance++;
            }
        }

        return distance;
    }
}