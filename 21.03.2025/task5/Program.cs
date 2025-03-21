public abstract class Sport
{
    public abstract void Play();

    public virtual void DisplayRules()
    {
        Console.WriteLine("General rules of the sport");
    }
}

public class Football: Sport
{
    public override void Play()
    {
        Console.WriteLine("Playing football");
    }

    public override void DisplayRules()
    {
        Console.WriteLine("Rules of football:");
        Console.WriteLine("- The game is played between two teams of 11 players each.");
        Console.WriteLine("- The objective is to score goals by getting the ball into the opposing team's goal.");
        Console.WriteLine("- The team with the most goals at the end of the match wins.");
    }
}

public class Basketball : Sport
{
    public override void Play()
    {
        Console.WriteLine("Playing basketball");
    }

    public override void DisplayRules()
    {
        Console.WriteLine("Rules of basketball:");
        Console.WriteLine("- The game is played between two teams of five players each.");
        Console.WriteLine("- The objective is to score points by shooting a ball through a hoop.");
        Console.WriteLine("- The team with the most points at the end of the match wins.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Sport football = new Football();
        Sport basketball = new Basketball();

        Console.WriteLine("Football: ");
        football.Play();
        football.DisplayRules();

        Console.WriteLine("\nBasketball: ");
        basketball.Play();
        basketball.DisplayRules();
    }
}