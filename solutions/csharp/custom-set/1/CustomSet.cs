using System;
using System.Collections.Generic;
using System.Linq;

public class CustomSet
{
    private readonly List<int> _elements = new();

    public CustomSet(params int[] values)
    {
        foreach (var value in values)
        {
            Add(value);
        }
    }

    public CustomSet Add(int value)
    {
        if (!Contains(value))
        {
            _elements.Add(value);
        }
        return this;
    }

    public bool Empty() => _elements.Count == 0;

    public bool Contains(int value) => _elements.Contains(value);

    public bool Subset(CustomSet right) => _elements.All(right.Contains);

    public bool Disjoint(CustomSet right) => !_elements.Any(right.Contains);

    public CustomSet Intersection(CustomSet right)
    {
        var common = _elements.Where(right.Contains).ToArray();
        return new CustomSet(common);
    }

    public CustomSet Difference(CustomSet right)
    {
        var diff = _elements.Where(e => !right.Contains(e)).ToArray();
        return new CustomSet(diff);
    }

    public CustomSet Union(CustomSet right)
    {
        // Start with all elements from this set
        var combined = new CustomSet(_elements.ToArray());
        // Add logic handles uniqueness automatically
        foreach (var element in right._elements)
        {
            combined.Add(element);
        }
        return combined;
    }

    public override bool Equals(object obj)
    {
        if (obj is not CustomSet other || _elements.Count != other._elements.Count)
            return false;

        return Subset(other);
    }

    public override int GetHashCode()
    {
        // Sort to ensure order doesn't change the hash
        return _elements.OrderBy(x => x).Aggregate(17, (current, x) => current * 31 + x.GetHashCode());
    }
}