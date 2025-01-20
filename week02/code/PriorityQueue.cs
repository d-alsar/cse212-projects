using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private readonly LinkedList<(string Value, int Priority)> _queue = new();

    /// <summary>
    /// Adds an item with a given priority to the queue.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var newItem = (Value: value, Priority: priority);

        if (_queue.Count == 0)
        {
            _queue.AddLast(newItem);
        }
        else
        {
            var current = _queue.First;
            while (current != null && current.Value.Priority >= priority)
            {
                current = current.Next;
            }

            if (current == null)
            {
                _queue.AddLast(newItem);
            }
            else
            {
                _queue.AddBefore(current, newItem);
            }
        }
    }

    /// <summary>
    /// Removes and returns the item with the highest priority.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var item = _queue.First.Value;
        _queue.RemoveFirst();
        return item.Value;
    }

    public override string ToString()
    {
        var items = new List<string>();
        foreach (var (Value, Priority) in _queue)
        {
            items.Add($"{Value} (Priority: {Priority})");
        }

        return string.Join(", ", items);
    }
}
