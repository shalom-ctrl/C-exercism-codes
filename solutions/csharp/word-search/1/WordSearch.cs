using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private readonly string[] _rows;
    private readonly int _width;
    private readonly int _height;

    public WordSearch(string grid)
    {
        _rows = grid.Split('\n');
        _height = _rows.Length;
        _width = _rows[0].Length;
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var results = new Dictionary<string, ((int, int), (int, int))?>();

        // Directional vectors: {x, y}
        int[][] directions = new int[][]
        {
            new[] {1, 0},   // Right
            new[] {-1, 0},  // Left
            new[] {0, 1},   // Down
            new[] {0, -1},  // Up
            new[] {1, 1},   // Down-Right
            new[] {1, -1},  // Up-Right
            new[] {-1, 1},  // Down-Left
            new[] {-1, -1}  // Up-Left
        };

        foreach (var word in wordsToSearchFor)
        {
            results[word] = FindWord(word, directions);
        }

        return results;
    }

    private ((int, int), (int, int))? FindWord(string word, int[][] directions)
    {
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                // Start searching only if the first letter matches
                if (_rows[y][x] == word[0])
                {
                    foreach (var dir in directions)
                    {
                        var endPos = CheckDirection(word, x, y, dir[0], dir[1]);
                        if (endPos.HasValue)
                        {
                            // Convert to 1-based indexing: (x, y)
                            return ((x + 1, y + 1), (endPos.Value.Item1 + 1, endPos.Value.Item2 + 1));
                        }
                    }
                }
            }
        }
        return null;
    }

    private (int, int)? CheckDirection(string word, int startX, int startY, int dx, int dy)
    {
        for (int i = 1; i < word.Length; i++)
        {
            int nextX = startX + (dx * i);
            int nextY = startY + (dy * i);

            // Boundary check
            if (nextX < 0 || nextX >= _width || nextY < 0 || nextY >= _height) 
                return null;

            // Letter match check
            if (_rows[nextY][nextX] != word[i]) 
                return null;
        }
        return (startX + dx * (word.Length - 1), startY + dy * (word.Length - 1));
    }
}