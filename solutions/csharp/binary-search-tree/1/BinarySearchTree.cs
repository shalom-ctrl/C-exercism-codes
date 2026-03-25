using System;
using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{
    public int Value { get; }
    public BinarySearchTree? Left { get; private set; }
    public BinarySearchTree? Right { get; private set; }

    public BinarySearchTree(int value)
    {
        Value = value;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        var enumerator = values.GetEnumerator();
        if (!enumerator.MoveNext()) throw new ArgumentException("Collection cannot be empty.");
        
        Value = enumerator.Current;
        while (enumerator.MoveNext())
        {
            Add(enumerator.Current);
        }
    }

    public BinarySearchTree Add(int value)
    {
        if (value <= Value)
        {
            if (Left == null) Left = new BinarySearchTree(value);
            else Left.Add(value);
        }
        else
        {
            if (Right == null) Right = new BinarySearchTree(value);
            else Right.Add(value);
        }
        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        // In-order traversal: Left -> Root -> Right
        if (Left != null)
        {
            foreach (var val in Left) yield return val;
        }

        yield return Value;

        if (Right != null)
        {
            foreach (var val in Right) yield return val;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}