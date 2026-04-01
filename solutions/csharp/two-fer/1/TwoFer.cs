using System;

public static class TwoFer
{
    // By setting name = "you", we handle both cases in one method.
    // If the caller provides a name, it overwrites "you".
    // If they provide nothing, it defaults to "you".
    public static string Speak(string name = "you")
    {
        return $"One for {name}, one for me.";
    }
}