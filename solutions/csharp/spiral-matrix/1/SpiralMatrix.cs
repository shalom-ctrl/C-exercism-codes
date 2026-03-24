using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int[,] matrix = new int[size, size];
        
        int top = 0;
        int bottom = size - 1;
        int left = 0;
        int right = size - 1;
        
        int currentNumber = 1;

        while (currentNumber <= size * size)
        {
            // 1. Traverse Right
            for (int i = left; i <= right; i++)
            {
                matrix[top, i] = currentNumber++;
            }
            top++; // Move the top boundary down

            // 2. Traverse Down
            for (int i = top; i <= bottom; i++)
            {
                matrix[i, right] = currentNumber++;
            }
            right--; // Move the right boundary left

            // 3. Traverse Left
            for (int i = right; i >= left; i--)
            {
                matrix[bottom, i] = currentNumber++;
            }
            bottom--; // Move the bottom boundary up

            // 4. Traverse Up
            for (int i = bottom; i >= top; i--)
            {
                matrix[i, left] = currentNumber++;
            }
            left++; // Move the left boundary right
        }

        return matrix;
    }
}
