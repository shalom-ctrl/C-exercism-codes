using System;
using System.Collections.Generic;
using System.Linq;

public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        bool list1InList2 = IsSublist(list1, list2);
        bool list2InList1 = IsSublist(list2, list1);

        if (list1InList2 && list2InList1)
            return SublistType.Equal;
        
        if (list1InList2)
            return SublistType.Sublist;
        
        if (list2InList1)
            return SublistType.Superlist;

        return SublistType.Unequal;
    }

    private static bool IsSublist<T>(List<T> sub, List<T> super) 
        where T : IComparable
    {
        // An empty list is a sublist of anything
        if (sub.Count == 0) return true;
        
        // A larger list cannot be a sublist of a smaller one
        if (sub.Count > super.Count) return false;

        // Sliding window check
        for (int i = 0; i <= super.Count - sub.Count; i++)
        {
            if (IsMatchAt(sub, super, i)) return true;
        }

        return false;
    }

    private static bool IsMatchAt<T>(List<T> sub, List<T> super, int offset) 
        where T : IComparable
    {
        for (int i = 0; i < sub.Count; i++)
        {
            if (sub[i].CompareTo(super[offset + i]) != 0)
                return false;
        }
        return true;
    }
}