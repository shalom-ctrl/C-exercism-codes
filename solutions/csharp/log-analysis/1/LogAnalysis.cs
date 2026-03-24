using System;

public static class LogAnalysis 
{
    // Task 1: Returns the part of the string following the delimiter
    public static string SubstringAfter(this string str, string delimiter)
    {
        int index = str.IndexOf(delimiter);
        // Add the length of the delimiter to start extracting right after it
        return str.Substring(index + delimiter.Length);
    }

    // Task 2: Returns the part of the string between two delimiters
    public static string SubstringBetween(this string str, string start, string end)
    {
        int startIndex = str.IndexOf(start) + start.Length;
        int endIndex = str.IndexOf(end);
        return str.Substring(startIndex, endIndex - startIndex);
    }
    
    // Task 3: Returns the message (everything after ": ")
    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }

    // Task 4: Returns the log level (everything between "[" and "]")
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}