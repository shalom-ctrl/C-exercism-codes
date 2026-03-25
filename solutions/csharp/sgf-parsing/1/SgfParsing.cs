using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// This class MUST be present for the Parser to return the correct type
public class SgfTree
{
    public SgfTree(IDictionary<string, string[]> data, params SgfTree[] children)
    {
        Data = data;
        Children = children;
    }

    public IDictionary<string, string[]> Data { get; }
    public SgfTree[] Children { get; }
}

public class SgfParser
{
    public static SgfTree ParseTree(string input)
    {
        if (string.IsNullOrEmpty(input) || input[0] != '(' || input[^1] != ')')
            throw new ArgumentException("Invalid SGF format.");

        int pos = 1;
        var result = ParseNodes(input, ref pos);
        
        // Final check to ensure we ended on the closing parenthesis
        if (pos < input.Length && input[pos] == ')') pos++;
        
        return result;
    }

    private static SgfTree ParseNodes(string input, ref int pos)
    {
        if (pos >= input.Length || input[pos] != ';') 
            throw new ArgumentException("Node must start with ';'");
        
        var nodesInSequence = new List<IDictionary<string, string[]>>();
        
        // Parse a sequence of nodes like ;A[1];B[2]
        while (pos < input.Length && input[pos] == ';')
        {
            pos++;
            var properties = new Dictionary<string, string[]>();
            
            while (pos < input.Length && char.IsLetter(input[pos]))
            {
                // Validation: Keys must be UPPERCASE
                if (!char.IsUpper(input[pos])) 
                    throw new ArgumentException("Property keys must be uppercase.");

                string key = ParseKey(input, ref pos);
                var values = new List<string>();

                // Validation: Property must have at least one [value]
                if (pos >= input.Length || input[pos] != '[')
                    throw new ArgumentException("Properties must have a value.");

                while (pos < input.Length && input[pos] == '[')
                {
                    values.Add(ParseValue(input, ref pos));
                }
                properties[key] = values.ToArray();
            }
            nodesInSequence.Add(properties);
        }

        // Parse children (variations)
        var children = new List<SgfTree>();
        while (pos < input.Length && input[pos] == '(')
        {
            pos++; // Skip '('
            children.Add(ParseNodes(input, ref pos));
            if (pos >= input.Length || input[pos] != ')') 
                throw new ArgumentException("Missing closing parenthesis.");
            pos++; // Skip ')'
        }

        return BuildTreeFromSequence(nodesInSequence, children.ToArray());
    }

    private static SgfTree BuildTreeFromSequence(List<IDictionary<string, string[]>> sequence, SgfTree[] finalChildren)
    {
        if (sequence.Count == 0) throw new ArgumentException("Empty node sequence.");
        
        SgfTree current = null;
        for (int i = sequence.Count - 1; i >= 0; i--)
        {
            var childArr = (current == null) ? finalChildren : new[] { current };
            current = new SgfTree(sequence[i], childArr);
        }
        return current;
    }

    private static string ParseKey(string input, ref int pos)
    {
        int start = pos;
        while (pos < input.Length && char.IsUpper(input[pos])) pos++;
        return input[start..pos];
    }

    private static string ParseValue(string input, ref int pos)
    {
        pos++; // Skip '['
        var sb = new StringBuilder();
        bool escaped = false;

        while (pos < input.Length)
        {
            char c = input[pos++];
            if (escaped)
            {
                if (c != '\n') sb.Append(c);
                escaped = false;
            }
            else if (c == '\\') escaped = true;
            else if (c == ']') return sb.ToString();
            else if (c == '\n') sb.Append(c);
            else if (char.IsWhiteSpace(c)) sb.Append(' ');
            else sb.Append(c);
        }
        throw new ArgumentException("Unclosed property value.");
    }
}