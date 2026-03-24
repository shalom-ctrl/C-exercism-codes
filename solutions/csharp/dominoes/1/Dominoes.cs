using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var list = dominoes.ToList();
        if (!list.Any()) return true;

        // 1. Check if every "station" has an even number of connections
        var counts = new Dictionary<int, int>();
        foreach (var (a, b) in list)
        {
            counts[a] = counts.GetValueOrDefault(a) + 1;
            counts[b] = counts.GetValueOrDefault(b) + 1;
        }

        if (counts.Values.Any(v => v % 2 != 0)) return false;

        // 2. Build the graph (Adjacency List)
        var adj = new Dictionary<int, List<int>>();
        foreach (var (a, b) in list)
        {
            if (!adj.ContainsKey(a)) adj[a] = new List<int>();
            if (!adj.ContainsKey(b)) adj[b] = new List<int>();
            adj[a].Add(b);
            adj[b].Add(a);
        }

        // 3. Ensure all dominoes are part of the same connected component
        int startNode = list.First().Item1;
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(startNode);
        visited.Add(startNode);

        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            foreach (var neighbor in adj[curr])
            {
                if (visited.Add(neighbor)) queue.Enqueue(neighbor);
            }
        }

        // If we didn't visit every unique number present in the dominoes, it's disconnected
        return visited.Count == counts.Keys.Count;
    }
}