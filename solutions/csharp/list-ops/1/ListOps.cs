using System;
using System.Collections.Generic;

public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        int count = 0;
        foreach (var _ in input) count++;
        return count;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        var result = new List<T>();
        // Iterate backwards through the input list
        for (int i = Length(input) - 1; i >= 0; i--)
        {
            result.Add(input[i]);
        }
        return result;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        var result = new List<TOut>();
        foreach (var item in input)
        {
            result.Add(map(item));
        }
        return result;
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        var result = new List<T>();
        foreach (var item in input)
        {
            if (predicate(item)) result.Add(item);
        }
        return result;
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        TOut accumulator = start;
        foreach (var item in input)
        {
            accumulator = func(accumulator, item);
        }
        return accumulator;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        TOut accumulator = start;
        for (int i = Length(input) - 1; i >= 0; i--)
        {
            accumulator = func(input[i], accumulator);
        }
        return accumulator;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        var result = new List<T>();
        foreach (var list in input)
        {
            result = Append(result, list);
        }
        return result;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        var result = new List<T>();
        foreach (var item in left) result.Add(item);
        foreach (var item in right) result.Add(item);
        return result;
    }
}