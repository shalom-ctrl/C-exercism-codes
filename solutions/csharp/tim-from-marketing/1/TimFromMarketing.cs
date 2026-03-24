using System;

public static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        // 1. Handle the ID prefix
        // If id is null, the prefix is an empty string.
        // If id has a value, we format it as "[id] - ".
        string idPrefix = id.HasValue ? $"[{id}] - " : "";

        // 2. Handle the Department
        // We use the ?? operator to provide "OWNER" as a fallback.
        // Then we use the ?. operator just in case (though "OWNER" isn't null).
        string departmentName = (department ?? "OWNER").ToUpper();

        // 3. Combine everything
        return $"{idPrefix}{name} - {departmentName}";
    }
}