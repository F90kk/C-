public class Trainer
{
    public string Name { get; set; }
    public Trainer(string name)
    {
        Name = name;
    }

    public void Train()
    {
        Console.WriteLine($"Trainet {Name} is training clietns");
    }
}

public class GymEquipment
{
    public string EquipmentName { get; set; }

    public GymEquipment(string equipmentName)
    {
        EquipmentName = equipmentName;
    }

    public void UseEquiment()
    {
        Console.WriteLine($"Using {EquipmentName} for training");
    }
}

public class Membership
{
    public string ClientName { get; set; }
    public int DurationDays { get; set; }

    public Membership(string clientName, int durationDays)
    {
        ClientName = clientName;
        DurationDays = durationDays;
    }

    public void DisplayMembershipInfo()
    {
        Console.WriteLine($"Client: {ClientName}, Membership Duration: {DurationDays} days");
    }
}

public class Gym
{
    public string GymName { get; set; }
    public Trainer[] Trainers { get; set; }
    private GymEquipment Equipment { get; set; }
    public Membership[] Memberships { get; set; }

    public Gym(string gymName, Trainer[] trainers, string equipment, Membership[] memberships)
    {
        GymName = gymName;
        Trainers = trainers;
        Equipment = new GymEquipment(equipment);
        Memberships = memberships;
    }

    public void TrainClients()
    {
        Console.WriteLine($"Training session at {GymName}:\n");
        Equipment.UseEquiment();
        foreach (var trainer in Trainers)
        {
            trainer.Train();
        }

        Console.WriteLine("\nClients participating in the training");
        foreach (var membership in Memberships)
        {
            membership.DisplayMembershipInfo();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Trainer trainer1 = new Trainer("Vladimir");
        Trainer trainer2 = new Trainer("Pavel");

        Membership membership1 = new Membership("Alan", 30);
        Membership membership2 = new Membership("Misha", 30);

        Gym gym1 = new Gym(
            "FitClub",
            new Trainer[] { trainer1, trainer2 },
            "Treadmill",
            new Membership[] { membership1, membership2 });

        Gym gym2 = new Gym(
           "PowerZone",
           new Trainer[] { trainer1 },
           "Elliptical Machine",
           new Membership[] { new Membership("Charlie", 21) }
       );

        Gym[] gyms = new Gym[] { gym1, gym2 };

        foreach (var gym in gyms)
        {
            gym.TrainClients();
        }
    }
}