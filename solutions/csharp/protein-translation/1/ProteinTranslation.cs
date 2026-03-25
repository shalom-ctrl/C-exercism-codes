using System;
using System.Collections.Generic;

public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        var proteins = new List<string>();

        for (int i = 0; i < strand.Length; i += 3)
        {
            // Extract a 3-nucleotide codon
            string codon = strand.Substring(i, 3);
            string aminoAcid = GetAminoAcid(codon);

            if (aminoAcid == "STOP")
            {
                break;
            }

            proteins.Add(aminoAcid);
        }

        return proteins.ToArray();
    }

    private static string GetAminoAcid(string codon) => codon switch
    {
        "AUG" => "Methionine",
        "UUU" or "UUC" => "Phenylalanine",
        "UUA" or "UUG" => "Leucine",
        "UCU" or "UCC" or "UCA" or "UCG" => "Serine",
        "UAU" or "UAC" => "Tyrosine",
        "UGU" or "UGC" => "Cysteine",
        "UGG" => "Tryptophan",
        "UAA" or "UAG" or "UGA" => "STOP",
        _ => throw new Exception("Invalid codon")
    };
}