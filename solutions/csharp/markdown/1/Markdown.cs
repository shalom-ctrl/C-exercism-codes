using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class Markdown
{
    private static string Wrap(string text, string tag) => $"<{tag}>{text}</{tag}>";

    private static string ParseInline(string markdown)
    {
        // Parse Strong (__) and Emphasis (_)
        var strong = Regex.Replace(markdown, @"__(.+)__", "<strong>$1</strong>");
        var em = Regex.Replace(strong, @"_(.+)_", "<em>$1</em>");
        return em;
    }

    private static string ParseHeader(string line, out bool isHeader)
    {
        int count = line.TakeWhile(c => c == '#').Count();
        
        if (count > 0 && count <= 6)
        {
            isHeader = true;
            return Wrap(line[(count + 1)..], $"h{count}");
        }

        isHeader = false;
        return line;
    }

    private static string ParseLineItem(string line, out bool isListItem)
    {
        if (line.StartsWith("* "))
        {
            isListItem = true;
            return Wrap(ParseInline(line[2..]), "li");
        }

        isListItem = false;
        return line;
    }

    public static string Parse(string markdown)
    {
        var lines = markdown.Split('\n');
        var result = new StringBuilder();
        bool inList = false;

        foreach (var line in lines)
        {
            // 1. Try to parse as Header
            var processedLine = ParseHeader(line, out bool isHeader);

            // 2. Try to parse as List Item if not a header
            if (!isHeader)
            {
                processedLine = ParseLineItem(line, out bool isListItem);

                // Handle List State (Opening/Closing <ul>)
                if (isListItem && !inList)
                {
                    result.Append("<ul>");
                    inList = true;
                }
                else if (!isListItem && inList)
                {
                    result.Append("</ul>");
                    inList = false;
                }

                // 3. If neither, it's a paragraph (unless it's already a list item)
                if (!isListItem)
                {
                    processedLine = Wrap(ParseInline(line), "p");
                }
            }
            else if (inList)
            {
                // If we hit a header while in a list, close the list
                result.Append("</ul>");
                inList = false;
            }

            result.Append(processedLine);
        }

        if (inList) result.Append("</ul>");

        return result.ToString();
    }
}