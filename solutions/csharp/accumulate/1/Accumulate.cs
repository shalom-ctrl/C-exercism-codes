using System;
using System.Collections.Generic;

public static class AccumulateExtensions
{
    public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
    {
        foreach (var item in collection)
        {
            // Apply the transformation and yield the result back one by one
            yield return func(item);
        }
    }
}