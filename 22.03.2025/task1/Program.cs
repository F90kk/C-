public abstract class SportEvent
{
    public string Name { get; set; }

    protected SportEvent(string name)
    {
        Name = name;
    }

    public abstract void StartEvent();
}

public class Football : SportEvent
{
    public Football(string name) : base(name) { }

    public override void StartEvent()
    {
        Console.WriteLine($"Starting football math: {Name}");    }
}

public class Basketball : SportEvent
{
    public Basketball(string name) : base(name) { }

    public override void StartEvent()
    {
        Console.WriteLine($"Starting swimming competition: {Name}");
    }
}

public class Tennis : SportEvent
{
    public Tennis(string name) : base(name) { }

    public override void StartEvent()
    {
        Console.WriteLine($"Starting tennis match: {Name}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        SportEvent[] events = new SportEvent[]
        {
            new Football("World Cup Final"),
            new Basketball("NBA"),
            new Tennis("Wimbldon Final")
        };

        Console.WriteLine("Startign all sport events:\n");
        foreach (var sportEvent in events)
        {
            sportEvent.StartEvent();
            Console.WriteLine();
        }
    }
}