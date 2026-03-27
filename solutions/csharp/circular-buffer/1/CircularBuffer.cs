using System;

public class CircularBuffer<T>
{
    private readonly T[] _buffer;
    private int _readIndex = 0;
    private int _writeIndex = 0;
    private int _count = 0;
    private readonly int _capacity;

    public CircularBuffer(int capacity)
    {
        _capacity = capacity;
        _buffer = new T[capacity];
    }

    public T Read()
    {
        if (_count == 0)
        {
            throw new InvalidOperationException("Cannot read from an empty buffer.");
        }

        T value = _buffer[_readIndex];
        // Move read pointer forward and wrap around
        _readIndex = (_readIndex + 1) % _capacity;
        _count--;
        
        return value;
    }

    public void Write(T value)
    {
        if (_count == _capacity)
        {
            throw new InvalidOperationException("Cannot write to a full buffer.");
        }

        _buffer[_writeIndex] = value;
        // Move write pointer forward and wrap around
        _writeIndex = (_writeIndex + 1) % _capacity;
        _count++;
    }

    public void Overwrite(T value)
    {
        if (_count == _capacity)
        {
            // If full, effectively discard the oldest by performing a "dummy" read
            // No need to return the value, just advance the read pointer
            _readIndex = (_readIndex + 1) % _capacity;
            _count--; 
        }
        
        Write(value);
    }

    public void Clear()
    {
        _readIndex = 0;
        _writeIndex = 0;
        _count = 0;
        // Optional: Array.Clear(_buffer, 0, _capacity) if you need to help GC
    }
}