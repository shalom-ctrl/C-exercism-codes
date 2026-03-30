using System;
using System.Collections.Generic;
using System.Linq;

public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target < 0) throw new ArgumentException("Target cannot be negative.");
        if (target == 0) return Array.Empty<int>();

        // minCoinsCount[i] = fewest coins to make amount i
        // Initialize with target + 1 (an impossible high value)
        int[] minCoinsCount = Enumerable.Repeat(target + 1, target + 1).ToArray();
        int[] firstCoinUsed = new int[target + 1];

        minCoinsCount[0] = 0;

        for (int amount = 1; amount <= target; amount++)
        {
            foreach (int coin in coins)
            {
                if (coin <= amount && 1 + minCoinsCount[amount - coin] < minCoinsCount[amount])
                {
                    minCoinsCount[amount] = 1 + minCoinsCount[amount - coin];
                    firstCoinUsed[amount] = coin;
                }
            }
        }

        // If target was never reached
        if (minCoinsCount[target] > target)
            throw new ArgumentException("The target cannot be reached with given coins.");

        // Reconstruct the coin list
        var result = new List<int>();
        int remaining = target;
        while (remaining > 0)
        {
            int coin = firstCoinUsed[remaining];
            result.Add(coin);
            remaining -= coin;
        }

        return result.OrderBy(x => x).ToArray();
    }
}