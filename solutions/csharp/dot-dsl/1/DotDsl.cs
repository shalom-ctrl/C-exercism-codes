using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Attr
{
    public string Key { get; }
    public string Value { get; }

    public Attr(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public override bool Equals(object obj) => 
        obj is Attr other && Key == other.Key && Value == other.Value;

    public override int GetHashCode() => HashCode.Combine(Key, Value);
}

public class Node : IEnumerable
{
    public string Name { get; }
    // Renamed from Attributes to Attrs to match test expectations
    public List<Attr> Attrs { get; } = new();

    public Node(string name) => Name = name;

    public void Add(string key, string value) => Attrs.Add(new Attr(key, value));

    public override bool Equals(object obj) => 
        obj is Node other && Name == other.Name && Attrs.SequenceEqual(other.Attrs);

    public override int GetHashCode() => Name?.GetHashCode() ?? 0;

    IEnumerator IEnumerable.GetEnumerator() => Attrs.GetEnumerator();
}

public class Edge : IEnumerable
{
    public string U { get; }
    public string V { get; }
    public List<Attr> Attrs { get; } = new();

    public Edge(string u, string v)
    {
        U = u;
        V = v;
    }

    public void Add(string key, string value) => Attrs.Add(new Attr(key, value));

    public override bool Equals(object obj) => 
        obj is Edge other && U == other.U && V == other.V && Attrs.SequenceEqual(other.Attrs);

    public override int GetHashCode() => HashCode.Combine(U, V);

    IEnumerator IEnumerable.GetEnumerator() => Attrs.GetEnumerator();
}

public class Graph : IEnumerable
{
    public List<Node> Nodes { get; } = new();
    public List<Edge> Edges { get; } = new();
    public List<Attr> Attrs { get; } = new();

    // DSL Add methods
    public void Add(Node node) => Nodes.Add(node);
    public void Add(Edge edge) => Edges.Add(edge);
    public void Add(string key, string value) => Attrs.Add(new Attr(key, value));

    public override bool Equals(object obj) => 
        obj is Graph other && 
        Nodes.OrderBy(n => n.Name).SequenceEqual(other.Nodes.OrderBy(n => n.Name)) && 
        Edges.SequenceEqual(other.Edges) && 
        Attrs.SequenceEqual(other.Attrs);

    public override int GetHashCode() => HashCode.Combine(Nodes.Count, Edges.Count);

    IEnumerator IEnumerable.GetEnumerator() => Nodes.GetEnumerator();
}