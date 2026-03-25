using System;
using System.Collections.Generic;
using System.Linq;

public static class KillerSudokuHelper
{
    public static IEnumerable<int[]> Combinations(int sum, int size, int[] exclude)
    {
        var result = new List<int[]>();
        var availableDigits = Enumerable.Range(1, 9).Except(exclude).ToList();
        
        FindCombinations(sum, size, availableDigits, 0, new List<int>(), result);
        
        return result;
    }

    private static void FindCombinations(int targetSum, int remainingSize, List<int> digits, int startIndex, List<int> current, List<int[]> result)
    {
        // Base Case: found a combination of the right size
        if (remainingSize == 0)
        {
            if (targetSum == 0)
            {
                result.Add(current.ToArray());
            }
            return;
        }

        // Recursive Step: try adding digits from the available list
        for (int i = startIndex; i < digits.Count; i++)
        {
            int d = digits[i];

            // Pruning: if the current digit is already too big, 
            // no need to check further because the list is sorted.
            if (d > targetSum) break;

            current.Add(d);
            FindCombinations(targetSum - d, remainingSize - 1, digits, i + 1, current, result);
            current.RemoveAt(current.Count - 1); // Backtrack
        }
    }
}