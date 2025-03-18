Console.Write("Enter A: ");
double A = double.Parse(Console.ReadLine());
Console.Write("Enter N (> 0): ");
int N = int.Parse(Console.ReadLine());

if (N <= 0)
{
    Console.Write("ERROR: N <= 0!");
}
else
{
    Console.WriteLine($"A^N = {Math.Round(Math.Pow(A, N), 4)}");
}

