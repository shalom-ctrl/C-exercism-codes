using System;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        // 1. Convert to lowercase
        // 2. Filter: only keep characters between 'a' and 'z'
        // 3. Distinct: remove duplicates
        // 4. Count: check if we have all 26
        
        return input.ToLower()
                    .Where(ch => ch >= 'a' && ch <= 'z')
                    .Distinct()
                    .Count() == 26;
    }
}