using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private readonly string[] _rows;
    private readonly List<string> _students = new List<string>
    {
        "Alice", "Bob", "Charlie", "David", "Eve", "Fred", 
        "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"
    };

    public KindergartenGarden(string diagram)
    {
        _rows = diagram.Split('\n');
    }

    public IEnumerable<Plant> Plants(string student)
    {
        // Find the index of the student (Alice = 0, Bob = 1...)
        int studentIndex = _students.IndexOf(student);
        int startIndex = studentIndex * 2;

        // Collect the 4 plant characters (2 from each row)
        var plantChars = new List<char>
        {
            _rows[0][startIndex],
            _rows[0][startIndex + 1],
            _rows[1][startIndex],
            _rows[1][startIndex + 1]
        };

        // Map characters to the Plant enum
        return plantChars.Select(ParsePlant);
    }

    private Plant ParsePlant(char c) => c switch
    {
        'V' => Plant.Violets,
        'R' => Plant.Radishes,
        'C' => Plant.Clover,
        'G' => Plant.Grass,
        _ => throw new ArgumentException("Unknown plant type.")
    };
}