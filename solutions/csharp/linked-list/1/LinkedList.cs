using System;

public class Deque<T>
{
    private class Node
    {
        public T Value { get; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node(T value) => Value = value;
    }

    private Node _head;
    private Node _tail;

    // Add to the end (Tail)
    public void Push(T value)
    {
        var newNode = new Node(value);
        if (_tail == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            newNode.Previous = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }
    }

    // Remove from the end (Tail)
    public T Pop()
    {
        if (_tail == null) throw new InvalidOperationException("Route is empty.");
        
        T value = _tail.Value;
        _tail = _tail.Previous;

        if (_tail == null) _head = null;
        else _tail.Next = null;

        return value;
    }

    // Add to the beginning (Head)
    public void Unshift(T value)
    {
        var newNode = new Node(value);
        if (_head == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }
    }

    // Remove from the beginning (Head)
    public T Shift()
    {
        if (_head == null) throw new InvalidOperationException("Route is empty.");

        T value = _head.Value;
        _head = _head.Next;

        if (_head == null) _tail = null;
        else _head.Previous = null;

        return value;
    }
}