using System;

public static class SquareRoot
{
    public static int Root(int number)
    {
        // Base cases for 0 and 1
        if (number < 2) return number;

        long left = 1;
        long right = number;
        int result = 0;

        while (left <= right)
        {
            long mid = left + (right - left) / 2;
            long square = mid * mid;

            if (square == number)
            {
                return (int)mid;
            }

            if (square < number)
            {
                left = mid + 1;
                result = (int)mid;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }
}