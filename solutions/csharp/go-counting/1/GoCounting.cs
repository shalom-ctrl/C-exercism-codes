using System;
using System.Collections.Generic;
using System.Linq;

public enum Owner { None, Black, White }

public class GoCounting
{
    private readonly char[][] _board;
    private readonly int _width;
    private readonly int _height;

    public GoCounting(string input)
    {
        string[] lines = input.Split('\n');
        _board = lines.Select(l => l.ToCharArray()).ToArray();
        _height = _board.Length;
        _width = _board[0].Length;
    }

    public Tuple<Owner, HashSet<(int, int)>> Territory((int x, int y) coord)
    {
        // 1. Boundary Check
        if (coord.x < 0 || coord.x >= _width || coord.y < 0 || coord.y >= _height)
        {
            throw new ArgumentException("Invalid coordinate.");
        }

        // 2. Stone Check
        if (_board[coord.y][coord.x] != ' ')
        {
            return new Tuple<Owner, HashSet<(int, int)>>(Owner.None, new HashSet<(int, int)>());
        }

        HashSet<(int, int)> territory = new HashSet<(int, int)>();
        HashSet<Owner> borders = new HashSet<Owner>();
        Queue<(int, int)> queue = new Queue<(int, int)>();

        queue.Enqueue(coord);
        territory.Add(coord);

        while (queue.Count > 0)
        {
            (int cx, int cy) = queue.Dequeue();

            // Check 4 neighbors
            (int, int)[] neighbors = { (cx + 1, cy), (cx - 1, cy), (cx, cy + 1), (cx, cy - 1) };
            
            foreach (var neighbor in neighbors)
            {
                int nx = neighbor.Item1;
                int ny = neighbor.Item2;

                if (nx < 0 || nx >= _width || ny < 0 || ny >= _height) continue;

                char cell = _board[ny][nx];
                if (cell == ' ')
                {
                    if (territory.Add((nx, ny)))
                    {
                        queue.Enqueue((nx, ny));
                    }
                }
                else if (cell == 'B') borders.Add(Owner.Black);
                else if (cell == 'W') borders.Add(Owner.White);
            }
        }

        Owner owner = borders.Count == 1 ? borders.First() : Owner.None;
        return new Tuple<Owner, HashSet<(int, int)>>(owner, territory);
    }

    public Dictionary<Owner, HashSet<(int, int)>> Territories()
    {
        var allTerritories = new Dictionary<Owner, HashSet<(int, int)>>
        {
            [Owner.Black] = new HashSet<(int, int)>(),
            [Owner.White] = new HashSet<(int, int)>(),
            [Owner.None] = new HashSet<(int, int)>()
        };

        HashSet<(int, int)> visited = new HashSet<(int, int)>();

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                if (_board[y][x] == ' ' && !visited.Contains((x, y)))
                {
                    var result = Territory((x, y));
                    allTerritories[result.Item1].UnionWith(result.Item2);
                    visited.UnionWith(result.Item2);
                }
            }
        }
        
        return allTerritories;
    }
}