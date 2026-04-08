using System;
using System.Collections.Generic;
using System.Linq;

public class BinTree
{
    public BinTree(int value, BinTree? left, BinTree? right)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public int Value { get; }
    public BinTree? Left { get; }
    public BinTree? Right { get; }

    public override bool Equals(object? obj) =>
        obj is BinTree other &&
        Value == other.Value &&
        Equals(Left, other.Left) &&
        Equals(Right, other.Right);

    public override int GetHashCode() => HashCode.Combine(Value, Left, Right);
}

internal class Crumb
{
    public int Value { get; }
    public BinTree? Sibling { get; }
    public bool FromLeft { get; }

    public Crumb(int value, BinTree? sibling, bool fromLeft)
    {
        Value = value;
        Sibling = sibling;
        FromLeft = fromLeft;
    }

    public override bool Equals(object? obj) =>
        obj is Crumb other &&
        Value == other.Value &&
        FromLeft == other.FromLeft &&
        Equals(Sibling, other.Sibling);

    public override int GetHashCode() => HashCode.Combine(Value, Sibling, FromLeft);
}

public class Zipper
{
    private readonly BinTree _focus;
    private readonly IEnumerable<Crumb> _breadcrumbs;

    private Zipper(BinTree focus, IEnumerable<Crumb> breadcrumbs)
    {
        _focus = focus;
        _breadcrumbs = breadcrumbs;
    }

    public static Zipper FromTree(BinTree tree) => new Zipper(tree, Enumerable.Empty<Crumb>());

    public int Value() => _focus.Value;

    public Zipper SetValue(int newValue) => 
        new Zipper(new BinTree(newValue, _focus.Left, _focus.Right), _breadcrumbs);

    public Zipper SetLeft(BinTree? binTree) => 
        new Zipper(new BinTree(_focus.Value, binTree, _focus.Right), _breadcrumbs);

    public Zipper SetRight(BinTree? binTree) => 
        new Zipper(new BinTree(_focus.Value, _focus.Left, binTree), _breadcrumbs);

    public Zipper? Left() => _focus.Left == null 
        ? null 
        : new Zipper(_focus.Left, _breadcrumbs.Prepend(new Crumb(_focus.Value, _focus.Right, true)));

    public Zipper? Right() => _focus.Right == null 
        ? null 
        : new Zipper(_focus.Right, _breadcrumbs.Prepend(new Crumb(_focus.Value, _focus.Left, false)));

    public Zipper? Up()
    {
        if (!_breadcrumbs.Any()) return null;

        var lastCrumb = _breadcrumbs.First();
        var remainingCrumbs = _breadcrumbs.Skip(1);

        var parent = lastCrumb.FromLeft
            ? new BinTree(lastCrumb.Value, _focus, lastCrumb.Sibling)
            : new BinTree(lastCrumb.Value, lastCrumb.Sibling, _focus);

        return new Zipper(parent, remainingCrumbs);
    }

    public BinTree ToTree()
    {
        var current = this;
        while (current.Up() is Zipper parent)
        {
            current = parent;
        }
        return current._focus;
    }

    // Zipper Equality: Focus and Breadcrumbs must match
    public override bool Equals(object? obj) =>
        obj is Zipper other &&
        Equals(_focus, other._focus) &&
        _breadcrumbs.SequenceEqual(other._breadcrumbs);

    public override int GetHashCode() => HashCode.Combine(_focus, _breadcrumbs);
}