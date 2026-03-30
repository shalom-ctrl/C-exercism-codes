using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    // SortedDictionary keeps grades in order (1, 2, 3...)
    private readonly SortedDictionary<int, List<string>> _school = new();

    public bool Add(string student, int grade)
    {
        // 1. Ensure the student isn't already in the school
        if (_school.Values.Any(list => list.Contains(student)))
        {
            return false;
        }

        // 2. Initialize the grade list if it doesn't exist
        if (!_school.ContainsKey(grade))
        {
            _school[grade] = new List<string>();
        }

        // 3. Add the student
        _school[grade].Add(student);
        return true;
    }

    public IEnumerable<string> Roster()
    {
        // Sort grades (handled by SortedDictionary) 
        // then sort names within each grade alphabetically
        return _school.SelectMany(kvp => kvp.Value.OrderBy(name => name));
    }

    public IEnumerable<string> Grade(int grade)
    {
        // Return sorted list for specific grade, or empty if no students
        if (!_school.ContainsKey(grade))
        {
            return Array.Empty<string>();
        }

        return _school[grade].OrderBy(name => name);
    }
}