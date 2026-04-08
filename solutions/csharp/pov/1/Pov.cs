using System;
using System.Collections.Generic;
using System.Linq;

public static class Extensions
{
    public static IEnumerable<Tree> Sorted(this List<Tree> trees)
    {
        var sortedTrees = new List<Tree>(trees);

        sortedTrees.Sort((x, y) => string.Compare(x.Value, y.Value));

        return sortedTrees;
    }

    public static Queue<Tree> ToQueue(this List<Tree> trees)
    {
        var queue = new Queue<Tree>();

        foreach (var tree in trees)
        {
            queue.Enqueue(tree);
        }

        return queue;
    }
}

public class Tree
{
    public readonly string Value;
    public List<Tree> Children;

    public Tree(string value, params Tree[] children)
    {
        Value = value;

        Children = new List<Tree>(children);
    }

    public Tree Clone() => new Tree(Value, Children.Select(c => c.Clone()).ToArray());

    private IEnumerable<Tree> InOrderTraversal()
    {
        yield return this;

        foreach (var child in Children.Sorted())
        {
            foreach (var tree in child.InOrderTraversal())
            {
                yield return tree;
            }
        }
    }

    public List<Tree> PathToChild(string to)
    {
        var path = new Stack<Tree>();

        PathToChild(to, path);

        if (path.Count == 0) throw new ArgumentException($"'{to}' does not exist in this tree.");

        return new List<Tree>(path.Reverse());
    }

    private bool PathToChild(string to, Stack<Tree> path)
    {
        path.Push(this);

        if (this.Value == to) return true;

        foreach (var child in Children)
        {
            if (child.PathToChild(to, path)) return true;
        }

        path.Pop();

        return false;
    }

    public override string ToString() => string.Join(" ", InOrderTraversal().Select(t => t.Value));

    public override bool Equals(object obj) => Equals(obj as Tree);

    public bool Equals(Tree other) => other == null ? false : this.ToString() == other.ToString();

    public override int GetHashCode() => ToString().GetHashCode();
}

public static class Pov
{
    public static Tree FromPov(Tree tree, string from)
    {
        var clone = tree.Clone();
        var path = clone.PathToChild(from).ToQueue();

        if (path.Count == 1) return clone;

        var root = path.Dequeue();

        while (path.Count > 0)
        {
            var newRoot = path.Dequeue();

            var filteredChildren = root.Children.Where(child => child.Value != newRoot.Value).ToList();

            root.Children = filteredChildren;

            newRoot.Children.Add(root);

            root = newRoot;
        }

        clone = root;

        return clone;
    }

    private static IEnumerable<string> Merge(List<string> fromPath, List<string> toPath)
    {
        var commonRoot = string.Empty;

        while (fromPath[0] == toPath[0])
        {
            commonRoot = fromPath[0];
            fromPath.RemoveAt(0);
            toPath.RemoveAt(0);

            if (fromPath.Count == 0 || toPath.Count == 0) break;
        }

        fromPath.Reverse();

        var mergedPath = new List<string>();

        mergedPath.AddRange(fromPath);
        mergedPath.Add(commonRoot);
        mergedPath.AddRange(toPath);

        return mergedPath;
    }

    public static IEnumerable<string> PathTo(string from, string to, Tree tree) =>
        Merge(
            tree.PathToChild(from).Select(t => t.Value).ToList(),
            tree.PathToChild(to).Select(t => t.Value).ToList()
        );
}