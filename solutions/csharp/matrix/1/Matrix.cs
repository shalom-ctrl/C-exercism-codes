using System;
using System.Collections.Generic;
using System.Linq;

public class Matrix
{
    private readonly int[][] _matrix;

    public Matrix(string input)
    {
        // 1. Split by newlines to get rows
        string[] rowStrings = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        _matrix = new int[rowStrings.Length][];

        for (int i = 0; i < rowStrings.Length; i++)
        {
            // 2. Split each row by spaces and parse to integers
            _matrix[i] = rowStrings[i]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }

    public int[] Row(int row)
    {
        // Note: Tests usually use 1-based indexing for these exercises
        return _matrix[row - 1];
    }

    public int[] Column(int col)
    {
        // We iterate through every row and pick out the element at the column index
        return _matrix.Select(row => row[col - 1]).ToArray();
    }
}