using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        // Task 1: Determine the rate based on current balance
        if (balance < 0) 
            return 3.213f;
        if (balance < 1000m) 
            return 0.5f;
        if (balance < 5000m) 
            return 1.621f;
        
        return 2.475f;
    }

    public static decimal Interest(decimal balance)
    {
        // Task 2: Calculate the interest amount
        // We cast the float rate to decimal to keep the math precise
        decimal rate = (decimal)InterestRate(balance);
        return balance * (rate / 100m);
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        // Task 3: Add the interest to the current balance
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        // Task 4: Use a loop to compound interest annually until target is reached
        int years = 0;
        decimal currentBalance = balance;

        while (currentBalance < targetBalance)
        {
            currentBalance = AnnualBalanceUpdate(currentBalance);
            years++;
        }

        return years;
    }
}