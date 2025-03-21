class Program
{
    static void HanoiTower(int n, char fromRod, char toRod, char auxRod)
    {
        if (n == 1)
        {
            Console.WriteLine($"Move disk 1 from rod {fromRod} to rod {fromRod}");
            return;
        }

        HanoiTower(n - 1, fromRod, auxRod, toRod);
        Console.WriteLine($"Move disk {n} from rod {fromRod} to rod {toRod}");

        HanoiTower(n - 1, auxRod, toRod, fromRod);

    }

    static void Main(string[] args)
    {
        int numberOfDisks = int.Parse(Console.ReadLine());
        HanoiTower(numberOfDisks, 'A', 'C', 'B');
    }
}