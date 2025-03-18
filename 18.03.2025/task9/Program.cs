double A = 0;
double B = Math.PI / 4;
int M = 20;
double H = (B - A) / M;

for (double x = A; x <= B; x += H)
{
    double Fx = Math.Sin(x) - Math.Tan(x);
    Console.WriteLine($"x = {x:F6}\t Fx = {Fx:F6}");
}