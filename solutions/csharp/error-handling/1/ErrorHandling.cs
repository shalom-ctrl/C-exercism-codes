using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        // Explicitly signal an error to the caller
        throw new Exception("An error occurred.");
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        // Try to parse. Return the number if valid, null if invalid.
        if (int.TryParse(input, out int result))
        {
            return result;
        }
        return null;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        // The standard .NET "Try" pattern
        return int.TryParse(input, out result);
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        // The 'using' statement ensures Dispose() is called 
        // even if the code inside the block throws an exception.
        using (disposableObject)
        {
            throw new Exception("Triggering an exception to test disposal.");
        }
    }
}