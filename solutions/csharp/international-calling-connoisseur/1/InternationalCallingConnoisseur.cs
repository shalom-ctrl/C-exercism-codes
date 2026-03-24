using System;
using System.Collections.Generic;
using System.Linq;

public static class DialingCodes
{
    // Task 1: Initialize an empty dictionary
    public static Dictionary<int, string> GetEmptyDictionary() => 
        new Dictionary<int, string>();

    // Task 2: Return pre-populated data
    public static Dictionary<int, string> GetExistingDictionary() => 
        new Dictionary<int, string>
        {
            {1, "United States of America"},
            {55, "Brazil"},
            {91, "India"}
        };

    // Task 3: Create and add a single entry
    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName) => 
        new Dictionary<int, string> { { countryCode, countryName } };

    // Task 4: Add to an existing collection
    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    // Task 5: Safe retrieval (checking if key exists first)
    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode) => 
        existingDictionary.TryGetValue(countryCode, out string countryName) ? countryName : string.Empty;

    // Task 6: Existence check
    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode) => 
        existingDictionary.ContainsKey(countryCode);

    // Task 7: Update if key exists
    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (existingDictionary.ContainsKey(countryCode))
        {
            existingDictionary[countryCode] = countryName;
        }
        return existingDictionary;
    }

    // Task 8: Remove entry
    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    // Task 9: Find longest string value using LINQ
    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        if (existingDictionary.Count == 0) return string.Empty;

        return existingDictionary.Values
            .OrderByDescending(name => name.Length)
            .FirstOrDefault() ?? string.Empty;
    }
}