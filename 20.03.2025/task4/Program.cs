
public partial class Pet
{
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string OwnerName { get; set; }

    public Pet(string name, string species, int age, string ownerName)
    {
        Name = name;
        Species = species;
        Age = age;
        OwnerName = ownerName;
    }

    public override string ToString()
    {
        return $"{Name}, {Species}, {Age} years old, Owner: {OwnerName}";
    }
}

public partial class Pet
{
    public void UpdatePetInfo(string name, string species, int age, string ownerName)
    {
        Name = name;
        Species = species;
        Age = age;
        OwnerName = ownerName;
    }
}

public class VeterinaryClinic
{
    private Pet[] pets;

    public VeterinaryClinic(Pet[] pets)
    {
        this.pets = pets;
    }

    public Pet GetOldestPet()
    {
        if (pets.Length == 0)
        {
            throw new InvalidOperationException("No pets in the clinic.");
        }
        return pets.OrderByDescending(p => p.Age).FirstOrDefault();
    }

    public Pet[] GetPetsByOwner(string ownerName)
    {
        return pets.Where(p => p.OwnerName.Equals(ownerName, StringComparison.OrdinalIgnoreCase)).ToArray();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Pet[] pets = new Pet[]
        {
            new Pet("Buddy", "Dog", 3, "Alice"),
            new Pet("Max", "Cat", 5, "Bob"),
            new Pet("Charlie", "Dog", 2, "Alice"),
            new Pet("Whiskers", "Cat", 7, "Charlie"),
            new Pet("Rex", "Dog", 4, "Bob")
        };

        VeterinaryClinic clinic = new VeterinaryClinic(pets);

        Pet oldestPet = clinic.GetOldestPet();
        Console.WriteLine("Oldest Pet: " + oldestPet);

        Pet[] petsByAlice = clinic.GetPetsByOwner("Alice");
        Console.WriteLine("\nPets owned by Alice:");
        foreach (var pet in petsByAlice)
        {
            Console.WriteLine(pet);
        }

        Pet[] petsByBob = clinic.GetPetsByOwner("Bob");
        Console.WriteLine("\nPets owned by Bob:");
        foreach (var pet in petsByBob)
        {
            Console.WriteLine(pet);
        }
    }
}