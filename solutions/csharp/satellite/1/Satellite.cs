using System;
using System.Linq;
using System.Collections.Generic;

public record Tree(char Value, Tree? Left, Tree? Right);

public static class Satellite
{
    public static Tree? TreeFromTraversals(char[] preOrder, char[] inOrder)
    {
        // Validation: Lengths must match
        if (preOrder.Length != inOrder.Length)
            throw new ArgumentException("Traversals must have the same length.");

        // Validation: Must contain the same elements
        if (preOrder.OrderBy(c => c).SequenceEqual(inOrder.OrderBy(c => c)) == false)
            throw new ArgumentException("Traversals must contain the same elements.");

        // Validation: No repeating items (as per instructions)
        if (preOrder.Distinct().Count() != preOrder.Length)
            throw new ArgumentException("Traversals must contain unique elements.");

        return Build(preOrder, inOrder);
    }

    private static Tree? Build(ReadOnlySpan<char> preOrder, ReadOnlySpan<char> inOrder)
    {
        if (preOrder.IsEmpty) return null;

        // 1. The first element in pre-order is the root
        char rootValue = preOrder[0];
        
        // 2. Find the index of the root in the in-order array
        int rootIndexInOrder = inOrder.IndexOf(rootValue);

        // 3. Slice the arrays for the left and right subtrees
        // Left subtree in-order: characters before the rootIndex
        var leftInOrder = inOrder.Slice(0, rootIndexInOrder);
        // Left subtree pre-order: characters immediately following the root
        var leftPreOrder = preOrder.Slice(1, leftInOrder.Length);

        // Right subtree in-order: characters after the rootIndex
        var rightInOrder = inOrder.Slice(rootIndexInOrder + 1);
        // Right subtree pre-order: remaining characters
        var rightPreOrder = preOrder.Slice(1 + leftInOrder.Length);

        return new Tree(
            rootValue,
            Build(leftPreOrder, leftInOrder),
            Build(rightPreOrder, rightInOrder)
        );
    }
}