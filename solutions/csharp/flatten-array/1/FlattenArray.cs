using System;
using System.Collections;
using System.Collections.Generic;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach (var item in input)
        {
            if (item == null)
            {
                continue;
            }

            // Strings are technically IEnumerable, but in this context 
            // they are "supplies," not "boxes." We check for other collections.
            if (item is IEnumerable nested && item is not string)
            {
                foreach (var innerItem in Flatten(nested))
                {
                    yield return innerItem;
                }
            }
            else
            {
                yield return item;
            }
        }
    }
}