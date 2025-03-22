public abstract class Spacecraft
{
    public string Name { get; set; }
    protected Spacecraft(string name)
    {
        Name = name;
    }

    public abstract void DisplayInfo();
}

public interface ICargoShip
{
    int CargoCapacity { get; }
    void LoadCargo(int amount);
}

public interface IPassengerShip
{
    int PassengerCapacity { get; }
    void BoardPassengers(int count);
}

public class Freighter : Spacecraft, ICargoShip
{
    public int CargoCapacity { get; private set; }
    public Freighter(string name, int cargoCapacity) : base(name)
    {
        CargoCapacity = cargoCapacity;
    }

    public void LoadCargo(int amount)
    {
        Console.WriteLine($"Loading {amount} tons of cargo onto {Name}.");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Freighter: {Name}, Cargo Capacity: {CargoCapacity} tons");
    }
}

public class Shuttle : Spacecraft, IPassengerShip
{
    public int PassengerCapacity { get; private set; }
    public Shuttle(string name, int passengerCapacity) : base(name)
    {
        PassengerCapacity = passengerCapacity;
    }

    public void BoardPassengers(int count)
    {
        Console.WriteLine($"Boarding {count} passengers onto {Name}.");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Shuttle: {Name}, Passenger Capacity: {PassengerCapacity}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Spacecraft[] spacecrafts = new Spacecraft[]
        {
            new Freighter("Star Carrier", 500),
            new Shuttle("Orion Express", 200),
            new Freighter("Galaxy Hauler", 1000),
            new Shuttle("Apollo Voyager", 300)
        };

        Console.WriteLine("Searching for passenger ships:\n");

        foreach (var spacecraft in spacecrafts)
        {
            if (spacecraft is IPassengerShip passengerShip)
            {
                Console.WriteLine($"Found passenger ship: {spacecraft.Name}");
                passengerShip.BoardPassengers(100); 
                Console.WriteLine();
            }
        }

        Console.WriteLine("All spacecrafts:");
        foreach (var spacecraft in spacecrafts)
        {
            spacecraft.DisplayInfo();
        }
    }
}