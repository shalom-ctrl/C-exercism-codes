using System;

// Task 1: Define Account types
public enum AccountType
{
    Guest,
    User,
    Moderator
}

// Task 1: Define Permissions with the Flags attribute
[Flags]
public enum Permission : byte
{
    None   = 0b00000000, // 0
    Read   = 0b00000001, // 1
    Write  = 0b00000010, // 2
    Delete = 0b00000100, // 4
    All    = 0b00000111  // 7 (Read | Write | Delete)
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        return accountType switch
        {
            AccountType.Guest => Permission.Read,
            AccountType.User => Permission.Read | Permission.Write,
            AccountType.Moderator => Permission.All,
            _ => Permission.None
        };
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        // Task 2: Use Bitwise OR (|) to add a flag
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        // Task 3: Use Bitwise AND (&) with bitwise NOT (~) to remove a flag
        return current & ~revoke;
    }

    public static bool Check(Permission current, Permission check)
    {
        // Task 4: Use HasFlag to check if a specific bit is set
        // Note: None always returns true for HasFlag, but the tests usually 
        // focus on functional permissions like Read/Write.
        return current.HasFlag(check);
    }
}