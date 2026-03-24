using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        var output = new List<string>();
        
        // Parse flags
        bool showLineNumbers = flags.Contains("-n");
        bool onlyFileNames = flags.Contains("-l");
        bool ignoreCase = flags.Contains("-i");
        bool invertMatch = flags.Contains("-v");
        bool matchEntireLine = flags.Contains("-x");
        bool multipleFiles = files.Length > 1;

        StringComparison comparison = ignoreCase 
            ? StringComparison.OrdinalIgnoreCase 
            : StringComparison.Ordinal;

        foreach (var file in files)
        {
            var lines = File.ReadAllLines(file);
            bool fileHasMatch = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                bool isMatch;

                // Determine matching logic
                if (matchEntireLine)
                {
                    isMatch = line.Equals(pattern, comparison);
                }
                else
                {
                    isMatch = line.Contains(pattern, comparison);
                }

                // Apply inversion flag (-v)
                if (invertMatch) isMatch = !isMatch;

                if (isMatch)
                {
                    fileHasMatch = true;
                    
                    if (onlyFileNames)
                    {
                        output.Add(file);
                        break; // Move to the next file immediately
                    }

                    var sb = new StringBuilder();
                    
                    // Prepend filename if multiple files exist
                    if (multipleFiles) sb.Append($"{file}:");
                    
                    // Prepend line number (1-based)
                    if (showLineNumbers) sb.Append($"{i + 1}:");
                    
                    sb.Append(line);
                    output.Add(sb.ToString());
                }
            }
        }

        // Unix grep usually returns matches separated by newlines
        return string.Join("\n", output);
    }
}