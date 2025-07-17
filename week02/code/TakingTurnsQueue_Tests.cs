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
    private readonly PersonQueue _people = new PersonQueue();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }
    
    /// <summary>
    /// Represents a queue of people.
    /// </summary>
    public class PersonQueue
    {
        private readonly Queue<Person> _queue = new();
    
        public int Length => _queue.Count;
    
        public void Enqueue(Person person)
        {
            _queue.Enqueue(person);
        }
    
        public Person Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            return _queue.Dequeue();
        }
    
        public bool IsEmpty()
        {
            return _queue.Count == 0;
        }
    }
    
    /// <summary>
    /// Represents a person with a name and a number of turns.
    /// </summary>
    public class Person
    {
        public string Name { get; }
        public int Turns { get; set; }
    
        public Person(string name, int turns)
        {
            Name = name;
            Turns = turns;
        }
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left.  Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns.  An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns, re-enqueue as-is
            _people.Enqueue(person);
        }
        else
        {
            // Finite turns, decrement
            person.Turns--;
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        return person;
    }
}