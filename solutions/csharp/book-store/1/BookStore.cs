using System;
using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    private static readonly decimal BookPrice = 8m;
    private static readonly Dictionary<int, decimal> Discounts = new Dictionary<int, decimal>
    {
        { 1, 1.00m }, { 2, 0.95m }, { 3, 0.90m }, { 4, 0.80m }, { 5, 0.75m }
    };

    private static Dictionary<string, decimal> _memo = new();

    public static decimal Total(IEnumerable<int> books)
    {
        _memo.Clear();
        // Count occurrences of each book (1-5)
        var counts = new int[5];
        foreach (var book in books) counts[book - 1]++;
        
        // Sort descending so the most frequent books are always at the start
        var initialBasket = counts.Where(c => c > 0).OrderByDescending(c => c).ToList();
        
        return CalculateMinPrice(initialBasket);
    }

    private static decimal CalculateMinPrice(List<int> basket)
    {
        if (basket.Count == 0) return 0m;

        // Create a key for memoization
        string key = string.Join(",", basket);
        if (_memo.TryGetValue(key, out decimal cached)) return cached;

        decimal minPrice = decimal.MaxValue;

        // Try forming a group of size 'i', from 1 up to how many different books we have left
        for (int i = 1; i <= basket.Count; i++)
        {
            // Create a new basket by taking 1 copy of 'i' different books
            var nextBasket = new List<int>(basket);
            for (int j = 0; j < i; j++)
            {
                nextBasket[j]--;
            }

            // Clean up and re-sort to keep the state consistent
            var filteredNext = nextBasket.Where(c => c > 0).OrderByDescending(c => c).ToList();
            
            decimal currentPrice = (i * BookPrice * Discounts[i]) + CalculateMinPrice(filteredNext);
            minPrice = Math.Min(minPrice, currentPrice);
        }

        _memo[key] = minPrice;
        return minPrice;
    }
}