using Collections.Nodes;
using System.Collections;
using System.Xml.Linq;

namespace Collections.Collections;

public class CustomLinkedList<T> : IEnumerable<T>
{

    public CustomLinkedNodes<T>? First { get; private set; }
    public CustomLinkedNodes<T>? Last { get; private set; }
    public int Count { get; private set; }

    public CustomLinkedList()
    {
        Count = 0;
    }
    public CustomLinkedNodes<T> AddFirst(T value)
    {
        CustomLinkedNodes<T> newNode = new(value);
        if (First is null)
        {
            First = newNode;
            Last = newNode;
            First.Previous = null;
            First.Next = null;
        }
        else
        {
            var next = First;
            First = newNode;
            First.Next = next;
            next.Previous = First;
            First.Previous = null;
        }
        Count++;
        return newNode;
    }
    public CustomLinkedNodes<T> AddLast(T value)
    {
        CustomLinkedNodes<T> newNode = new(value);
        if (Last is null)
        {
            First = newNode;
            Last = newNode;
            Last.Previous = null;
            Last.Next = null;
        }
        else
        {
            var prev = Last;
            Last = newNode;
            Last.Previous = prev;
            prev.Next = Last;
            Last.Next = null;
        }
        Count++;
        return newNode;
    }

    public CustomLinkedNodes<T>? Find(T value)
    {
        CustomLinkedNodes<T>? current = First;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return current;
            }
            current = current.Next;
        }
        return default;
    }


    public CustomLinkedNodes<T> AddAfter(CustomLinkedNodes<T> after, T value)
    {
        if (after is null)
        {
            throw new ArgumentNullException(nameof(after));
        }
        CustomLinkedNodes<T> newNode = new CustomLinkedNodes<T>(value);
        CustomLinkedNodes<T> node = Find(after.Value);
        if (node != null)
        {
            CustomLinkedNodes<T> prev = node.Next;
            if (prev is null)
            {
                Last = newNode;
            }
            else
            {
                prev.Previous = newNode;
            }
            node.Next = newNode;
            newNode.Previous = node;
            newNode.Next = prev;

            Count++;
            return newNode;
        }
        return default;
    }


    public CustomLinkedNodes<T> AddBefore(CustomLinkedNodes<T> before, T value)
    {
        if (before is null)
        {
            throw new ArgumentNullException(nameof(before));
        }
        CustomLinkedNodes<T> newNode = new CustomLinkedNodes<T>(value);
        CustomLinkedNodes<T> node = Find(before.Value);
        if (node != null)
        {
            CustomLinkedNodes<T> previous = node.Previous;
            if (previous is null)
            {
                First = newNode;
            }
            else
            {
                previous.Next = newNode;
            }
            newNode.Previous = previous;
            newNode.Next = node;
            node.Previous = newNode;

            Count--;
            return newNode;
        }
        return newNode;
    }

    public bool Remove(T value)
    {
        var Node = First;


        while (Node != null)
        {
            if (Node.Value.Equals(value))
            {
                if (Node.Previous != null)
                {
                    Node.Next.Previous = Node.Next;
                }
                else
                {
                    First = Node.Next;
                }

                if (Node.Next !=null)
                {
                    Node.Next.Previous = Node.Previous;
                }
                else
                {
                    Last = Node.Previous;
                }
                Count--;
                return true;
            }

            Node = Node.Next;
        }
        return false;

    }

    public void Clear()
    {
        First = default;
        Last = default;
        Count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        CustomLinkedNodes<T>? temp = First;
        while (temp != null)
        {
            yield return temp.Value;
            temp = temp.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

