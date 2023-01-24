using System;

namespace DataStructures;

// реализация двусвязного списка
public class LinkedList<T>
{
    public Node Head;
    public Node Tail;

    public Node AddFirst(int value)
    {
        var newNode = new Node(value)
        {
            Next = Head
        };

        if (Head != null)
        {
            Head.Previous = newNode;
        }

        Tail ??= newNode;

        Head = newNode;
        return newNode;
    }

    public Node AddLast(int value)
    {
        var newNode = new Node(value);


        if (Tail != null)
        {
            Tail.Next = newNode;
        }

        Head ??= newNode;

        newNode.Previous = Tail;

        return newNode;
    }

    public Node AddAfter(Node node, int value)
    {
        var next = node.Next;

        var newNode = new Node(value)
        {
            Next = next,
            Previous = node
        };

        node.Next = newNode;
        next.Previous = newNode;

        if (node == Tail)
        {
            Tail = newNode;
        }

        return newNode;
    }

    public void PrintAll()
    {
        var current = Head;
        while (current != null)
        {
            Console.WriteLine(current.Value);

            current = current.Next;
        }
    }
}

public class Node
{
    public Node Next;
    public Node Previous;
    public readonly int Value;

    public Node(int value)
    {
        Value = value;
    }
}