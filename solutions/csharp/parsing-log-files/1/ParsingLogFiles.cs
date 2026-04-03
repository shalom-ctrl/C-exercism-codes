using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

public class LogParser
{
    public bool IsValidLine(string text) =>
        Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");

    public string[] SplitLogLine(string text) =>
        Regex.Split(text, @"<[\^*-=>]+>");

    public int CountQuotedPasswords(string lines) =>
        Regex.Matches(lines, @"""[^""]*?password[^""]*?""", RegexOptions.IgnoreCase).Count;

    public string RemoveEndOfLineText(string line) =>
        Regex.Replace(line, @"end-of-line\d+", "");

    public string[] ListLinesWithPasswords(string[] lines)
    {
        // The pattern \bpassword\S+ ensures "password" is a word start
        // and is followed by at least one non-whitespace character (\S+).
        var regex = new Regex(@"\bpassword\S+", RegexOptions.IgnoreCase);

        return lines.Select(line => 
        {
            var match = regex.Match(line);
            return match.Success 
                ? $"{match.Value}: {line}" 
                : $"--------: {line}";
        }).ToArray();
    }
}