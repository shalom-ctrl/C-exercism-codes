using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        // 1. Validate the operation input
        if (operation is null)
        {
            throw new ArgumentNullException(nameof(operation), "Operation cannot be null.");
        }

        if (operation == string.Empty)
        {
            throw new ArgumentException("Operation cannot be empty.", nameof(operation));
        }

        // 2. Perform the calculation based on the symbol
        switch (operation)
        {
            case "+":
                return $"{operand1} + {operand2} = {operand1 + operand2}";

            case "*":
                return $"{operand1} * {operand2} = {operand1 * operand2}";

            case "/":
                try
                {
                    // If operand2 is 0, C# throws a DivideByZeroException
                    return $"{operand1} / {operand2} = {operand1 / operand2}";
                }
                catch (DivideByZeroException)
                {
                    // We catch the specific error and return the required message
                    return "Division by zero is not allowed.";
                }

            default:
                // If it's anything else (like "-"), throw the OutOfRange exception
                throw new ArgumentOutOfRangeException(nameof(operation), "Unknown operation.");
        }
    }
}