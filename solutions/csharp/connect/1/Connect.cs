using System;
using System.Collections.Generic;
using System.Linq;

public enum ConnectWinner { White, Black, None }

public class Connect
{
    private readonly char[][] _board;
    private readonly int _rows;
    private readonly int _cols;

    public Connect(string[] input)
    {
        // Remove spaces and convert to a clean char grid
        _board = input.Select(row => row.Replace(" ", "").ToCharArray()).ToArray();
        _rows = _board.Length;
        _cols = _rows > 0 ? _board[0].Length : 0;
    }

    public ConnectWinner Result()
    {
        if (HasPlayerWon('O', isVertical: true)) return ConnectWinner.White;
        if (HasPlayerWon('X', isVertical: false)) return ConnectWinner.Black;
        return ConnectWinner.None;
    }

    private bool HasPlayerWon(char player, bool isVertical)
    {
        var starts = new List<(int r, int c)>();
        
        // Define starting positions based on player direction
        if (isVertical) // Player O: Top to Bottom
        {
            for (int c = 0; c < _cols; c++) if (_board[0][c] == player) starts.Add((0, c));
        }
        else // Player X: Left to Right
        {
            for (int r = 0; r < _rows; r++) if (_board[r][0] == player) starts.Add((r, 0));
        }

        if (starts.Count == 0) return false;

        // BFS to find the opposite side
        var queue = new Queue<(int r, int c)>(starts);
        var visited = new HashSet<(int r, int c)>(starts);

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();

            // Check if we reached the target side
            if (isVertical && r == _rows - 1) return true;
            if (!isVertical && c == _cols - 1) return true;

            foreach (var neighbor in GetNeighbors(r, c))
            {
                if (neighbor.nr >= 0 && neighbor.nr < _rows && 
                    neighbor.nc >= 0 && neighbor.nc < _cols &&
                    _board[neighbor.nr][neighbor.nc] == player &&
                    !visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return false;
    }

    private IEnumerable<(int nr, int nc)> GetNeighbors(int r, int c)
    {
        yield return (r - 1, c);     yield return (r - 1, c + 1);
        yield return (r, c - 1);     yield return (r, c + 1);
        yield return (r + 1, c - 1); yield return (r + 1, c);
    }
}