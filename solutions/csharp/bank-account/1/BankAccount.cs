using System;

public class BankAccount
{
    private readonly object _lock = new object();
    private decimal _balance;
    private bool _isOpen;

    public void Open()
    {
        lock (_lock)
        {
            if (_isOpen) throw new InvalidOperationException("Account is already open.");
            
            // Per the tests, reopening an account resets the balance
            _balance = 0;
            _isOpen = true;
        }
    }

    public void Close()
    {
        lock (_lock)
        {
            if (!_isOpen) throw new InvalidOperationException("Account is not open.");
            _isOpen = false;
        }
    }

    public decimal Balance
    {
        get
        {
            lock (_lock)
            {
                if (!_isOpen) throw new InvalidOperationException("Account is closed.");
                return _balance;
            }
        }
    }

    public void Deposit(decimal amount)
    {
        if (amount < 0) throw new InvalidOperationException("Cannot deposit negative amount.");

        lock (_lock)
        {
            if (!_isOpen) throw new InvalidOperationException("Account is closed.");
            _balance += amount;
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount < 0) throw new InvalidOperationException("Cannot withdraw negative amount.");

        lock (_lock)
        {
            if (!_isOpen) throw new InvalidOperationException("Account is closed.");
            if (_balance < amount) throw new InvalidOperationException("Insufficient funds.");
            
            _balance -= amount;
        }
    }
}