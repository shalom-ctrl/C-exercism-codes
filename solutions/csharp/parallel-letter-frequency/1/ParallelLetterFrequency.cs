using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public static class ParallelLetterFrequency
{
    public static async Task<Dictionary<char, int>> Calculate(IEnumerable<string> texts)
    {
        return await Task.Run(() =>
        {
            return texts
                .AsParallel() // Enable PLINQ
                .SelectMany(text => text.ToLower().Where(char.IsLetter)) // Flatten to lowercase letters
                .GroupBy(c => c) // Group by the character itself
                .ToDictionary(
                    group => group.Key, 
                    group => group.Count()
                );
        });
    }
}