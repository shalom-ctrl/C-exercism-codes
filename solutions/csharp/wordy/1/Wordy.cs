using System;
using System.Collections.Generic;
using System.Linq;

public static class Wordy
{
    public static int Answer(string question)
    {
        // 1. Basic Cleaning
        string stripped = question.Replace("What is ", "").Replace("?", "").Trim();
        if (string.IsNullOrEmpty(stripped)) throw new ArgumentException("Empty question.");

        // 2. Normalize multi-word operators
        stripped = stripped.Replace("multiplied by", "multiplied")
                           .Replace("divided by", "divided");

        string[] tokens = stripped.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // 3. Initial Number
        if (!int.TryParse(tokens[0], out int result))
        {
            throw new ArgumentException("First token must be a number.");
        }

        // 4. Sequential Processing
        int i = 1;
        while (i < tokens.Length)
        {
            string op = tokens[i];
            
            // Check for valid syntax: we expect an operator then a number
            if (i + 1 >= tokens.Length) throw new ArgumentException("Missing number after operator.");
            
            if (!int.TryParse(tokens[i + 1], out int nextNum))
            {
                // If it's another number instead of an operator, or a weird word
                throw new ArgumentException("Invalid syntax or unsupported operation.");
            }

            result = op switch
            {
                "plus" => result + nextNum,
                "minus" => result - nextNum,
                "multiplied" => result * nextNum,
                "divided" => result / nextNum,
                _ => throw new ArgumentException("Unknown operator.")
            };

            i += 2; // Skip the operator and the number we just used
        }

        return result;
    }
}