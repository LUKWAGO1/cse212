using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList : IEnumerable<int>
{
    private class Node
    {
        public int Value;
        public Node? Next;
        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node? head = null;
    private Node? tail = null;

    // Helper methods for tests
    public bool HeadAndTailAreNull() => head == null && tail == null;
    public bool HeadAndTailAreNotNull() => head != null && tail != null;

    public void InsertHead(int value)
    {
        Node newNode = new Node(value);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
        }
    }

    // Problem 1: InsertTail
    public void InsertTail(int value)
    {
        Node newNode = new Node(value);
        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
    }

    // Problem 2: RemoveTail
    public void RemoveTail()
    {
        if (head == null)
        {
            // List is empty
            return;
        }
        if (head == tail)
        {
            // Only one node
            head = tail = null;
            return;
        }
        // More than one node
        Node current = head;
        while (current.Next != null && current.Next != tail)
        {
            current = current.Next;
        }
        if (current.Next != null)
        {
            current.Next = null;
            tail = current;
        }
    }

    // Problem 3: Remove
    public void Remove(int value)
    {
        if (head == null)
            return;

        if (head.Value == value)
        {
            // Remove head
            head = head.Next;
            if (head == null)
                tail = null;
            return;
        }

        Node prev = head;
        Node? curr = head.Next;
        while (curr != null)
        {
            if (curr.Value == value)
            {
                prev.Next = curr.Next;
                if (curr == tail)
                    tail = prev;
                return;
            }
            prev = curr;
            curr = curr.Next;
        }
    }

    // Problem 4: Replace
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = head;
        while (curr != null)
        {
            if (curr.Value == oldValue)
                curr.Value = newValue;
            curr = curr.Next;
        }
    }

    // InsertAfter helper for tests
    public void InsertAfter(int afterValue, int newValue)
    {
        Node? curr = head;
        while (curr != null)
        {
            if (curr.Value == afterValue)
            {
                Node newNode = new Node(newValue);
                newNode.Next = curr.Next;
                curr.Next = newNode;
                if (curr == tail)
                    tail = newNode;
                return;
            }
            curr = curr.Next;
        }
    }

    // ToString for test output
    public override string ToString()
    {
        var parts = new List<string>();
        Node? curr = head;
        while (curr != null)
        {
            parts.Add(curr.Value.ToString());
            curr = curr.Next;
        }
        return "<LinkedList>{" + string.Join(", ", parts) + "}";
    }

    // Problem 5: Reverse iterator
    public IEnumerable<int> Reverse()
    {
        var stack = new Stack<int>();
        Node? curr = head;
        while (curr != null)
        {
            stack.Push(curr.Value);
            curr = curr.Next;
        }
        while (stack.Count > 0)
        {
            yield return stack.Pop();
        }
    }

    // Forward iterator for foreach
    public IEnumerator<int> GetEnumerator()
    {
        Node? curr = head;
        while (curr != null)
        {
            yield return curr.Value;
            curr = curr.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// Extension for test output
public static class EnumerableExtensions
{
    public static string AsString(this IEnumerable<int> source)
    {
        var parts = new List<string>();
        foreach (var item in source)
            parts.Add(item.ToString());
        return "<IEnumerable>{" + string.Join(", ", parts) + "}";
    }
}