using System;
using System.Collections.Generic;

public class Robot
{
    private static readonly Random _random = new Random();
    private static readonly HashSet<string> _usedNames = new HashSet<string>();
    private string _name;

    public string Name
    {
        get
        {
            if (_name == null)
            {
                _name = GenerateUniqueName();
            }
            return _name;
        }
    }

    public void Reset()
    {
        if (_name != null)
        {
            _usedNames.Remove(_name);
            _name = null;
        }
    }

    private string GenerateUniqueName()
    {
        string newName;
        do
        {
            char letter1 = (char)_random.Next('A', 'Z' + 1);
            char letter2 = (char)_random.Next('A', 'Z' + 1);
            int numbers = _random.Next(0, 1000); // 0 to 999
            
            newName = $"{letter1}{letter2}{numbers:D3}";
            
        } while (_usedNames.Contains(newName));

        _usedNames.Add(newName);
        return newName;
    }
}