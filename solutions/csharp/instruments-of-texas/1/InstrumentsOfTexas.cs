using System;

// 1. Complete the Custom Exception
public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner)
        : base(message, inner)
    {
        Operand1 = operand1;
        Operand2 = operand2;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
}

// 2. Implement the Test Harness with Exception Filtering
public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try
        {
            Multiply(x, y);
            return "Multiply succeeded";
        }
        // Filter: Both operands are negative
        catch (CalculationException ex) when (ex.Operand1 < 0 && ex.Operand2 < 0)
        {
            return $"Multiply failed for negative operands. {ex.InnerException.Message}";
        }
        // Filter: Catch remaining CalculationExceptions (mixed or positive operands)
        catch (CalculationException ex)
        {
            return $"Multiply failed for mixed or positive operands. {ex.InnerException.Message}";
        }
    }

    public void Multiply(int x, int y)
    {
        try
        {
            calculator.Multiply(x, y);
        }
        catch (OverflowException ex)
        {
            // Wrap the OverflowException in our custom CalculationException
            throw new CalculationException(x, y, ex.Message, ex);
        }
    }
}

// 3. The provided Calculator class (Do not modify)
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}