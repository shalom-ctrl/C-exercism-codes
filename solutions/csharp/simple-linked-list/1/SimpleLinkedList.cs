using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private Node _head;
    public int Count { get; private set; }

    // Internal node structure
    private class Node
    {
        public T Value { get; }
        public Node Next { get; set; }
        public Node(T value) => Value = value;
    }

    public SimpleLinkedList() { }

    public SimpleLinkedList(T value) : this() => Push(value);

    public SimpleLinkedList(IEnumerable<T> values) : this()
    {
        foreach (var value in values) Push(value);
    }

    public void Push(T value)
    {
        var newNode = new Node(value) { Next = _head };
        _head = newNode;
        Count++;
    }

    public T Pop()
    {
        if (_head == null) throw new InvalidOperationException("Empty list.");
        
        T value = _head.Value;
        _head = _head.Next;
        Count--;
        return value;
    }

    public SimpleLinkedList<T> Reverse()
    {
        // Pushing from one list to another naturally reverses the order
        return new SimpleLinkedList<T>(this);
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}