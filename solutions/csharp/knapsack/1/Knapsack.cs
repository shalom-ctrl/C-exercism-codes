using System;
using System.Collections.Generic;

public static class Knapsack
{
    // Change 'Item[]' to 'IEnumerable<(int weight, int value)>' to match the tests
    public static int MaximumValue(int maximumWeight, IEnumerable<(int weight, int value)> items)
    {
        // Convert the input to a list so we can access items by index easily
        var itemList = new List<(int weight, int value)>(items);
        int n = itemList.Count;
        
        // Standard DP table: Rows = items, Columns = weight capacity
        int[,] dp = new int[n + 1, maximumWeight + 1];

        for (int i = 1; i <= n; i++)
        {
            // Access the tuple's named fields (weight and value)
            var currentItem = itemList[i - 1];
            
            for (int w = 0; w <= maximumWeight; w++)
            {
                if (currentItem.weight <= w)
                {
                    // Either skip the item OR take it + best value from remaining weight
                    dp[i, w] = Math.Max(dp[i - 1, w], 
                                       dp[i - 1, w - currentItem.weight] + currentItem.value);
                }
                else
                {
                    // Item is too heavy for current capacity 'w'
                    dp[i, w] = dp[i - 1, w];
                }
            }
        }

        return dp[n, maximumWeight];
    }
}