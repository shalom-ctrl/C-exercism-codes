using System;
using System.Linq;

public static class RnaTranscription
{
    public static string ToRna(string strand)
    {
        return new string(strand.Select(nucleotide => nucleotide switch
        {
            'G' => 'C',
            'C' => 'G',
            'T' => 'A',
            'A' => 'U',
            _ => throw new ArgumentException("Invalid DNA nucleotide")
        }).ToArray());
    }
}