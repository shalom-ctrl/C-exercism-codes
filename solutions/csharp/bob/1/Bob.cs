using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        string input = statement.Trim();
        bool isSilence = string.IsNullOrWhiteSpace(input);
        bool isQuestion = !isSilence && input.EndsWith("?");
        
        bool isYelling = input.Any(char.IsLetter) && input.ToUpper() == input;
        if (isSilence)
        {
            return "Fine. Be that way!";
        }
        if (isYelling && isQuestion)
        {
            return "Calm down, I know what I'm doing!";
        }
        if (isYelling)
        {
            return "Whoa, chill out!";
        }
        if (isQuestion)
        {
            return "Sure.";
        }

        return "Whatever.";
    }
}