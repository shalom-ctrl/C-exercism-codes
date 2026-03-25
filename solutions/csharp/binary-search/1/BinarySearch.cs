using System;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int low = 0;
        int high = input.Length - 1;

        while (low <= high)
        {
            // Using (low + high) / 2 can cause overflow with very large arrays.
            // This version is safer:
            int mid = low + (high - low) / 2;

            if (input[mid] == value)
            {
                return mid;
            }
            
            if (input[mid] < value)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        // Standard way to indicate the value was not found
        return -1;
    }
}