class Program
{
    static void Mean(double X, double Y, out double AMean, out double GMean)
    {
        if (X <= 0 || Y <= 0)
        {
            throw new ArgumentException("X and Y must be positive numbers");
        }

        AMean = (X + Y) / 2;
        GMean = Math.Sqrt(X * Y);
    }

    static void Main(string[] args)
    {
        Console.Write("Enter X: ");
        double A = double.Parse(Console.ReadLine());
        Console.Write("Enter Y: ");
        double B = double.Parse(Console.ReadLine());
        Console.Write("Enter C: ");
        double C = double.Parse(Console.ReadLine());
        Console.Write("Enter D: ");
        double D = double.Parse(Console.ReadLine());

        double AMean, GMean;

        Mean(A, B, out AMean, out GMean);
        Console.WriteLine($"For pair (A, B): A = {A}, B = {B}");
        Console.WriteLine($"Arithmetic Mean: {AMean}, Geometric Mean: {GMean}");

        Mean(A, C, out AMean, out GMean);
        Console.WriteLine($"\nFor pair (A, C): A = {A}, C = {C}");
        Console.WriteLine($"Arithmetic Mean: {AMean}, Geometric Mean: {GMean}");

        Mean(A, D, out AMean, out GMean);
        Console.WriteLine($"\nFor pair (A, D): A = {A}, D = {D}");
        Console.WriteLine($"Arithmetic Mean: {AMean}, Geometric Mean: {GMean}");
    }
}