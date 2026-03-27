using System;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        // 1. Validation
        if (span < 0) throw new ArgumentException("Span cannot be negative.");
        if (span > digits.Length) throw new ArgumentException("Span cannot be greater than string length.");
        if (digits.Any(c => !char.IsDigit(c))) throw new ArgumentException("String must contain only digits.");

        // 2. Identity case
        if (span == 0) return 1;

        long maxProduct = 0;

        // 3. Sliding Window
        for (int i = 0; i <= digits.Length - span; i++)
        {
            long currentProduct = 1;
            
            for (int j = 0; j < span; j++)
            {
                // Convert char to int (e.g., '5' becomes 5)
                int val = digits[i + j] - '0';
                currentProduct *= val;
            }

            if (currentProduct > maxProduct)
            {
                maxProduct = currentProduct;
            }
        }

        return maxProduct;
    }
}