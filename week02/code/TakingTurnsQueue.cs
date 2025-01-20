/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>

public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new();

    public int Length => _people.Count;

    /// <summary>
    /// Add new people to the queue with a name and number of turns.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person is re-added to the queue unless
    /// their turns are exhausted. For infinite turns (0 or less), they are always re-added.
    /// </summary>
   
    public Person GetNextPerson()
    {
        if (_people.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns: Always re-add to the queue.
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // Decrement finite turns and re-add if they still have turns.
            person.Turns -= 1;
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return string.Join(", ", _people);
    }
}
