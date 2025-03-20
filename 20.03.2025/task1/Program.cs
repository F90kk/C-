public class Numbers
{
    public int a { get; set; }
    public int b { get; set; }

    public Numbers(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public Numbers()
    {
        a = 0;
        b = 0; 
    }

    public double Arithmetic_mean()
    {
        return (double) (a + b) / 2.0;
    }

    public double Expression_evaluation()
    {
        return Math.Pow(b, 3) + Math.Sqrt(a);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Numbers num = new Numbers();
        num.a = int.Parse(Console.ReadLine());
        num.b = int.Parse(Console.ReadLine());


        Console.WriteLine(num.Arithmetic_mean());
        Console.WriteLine(num.Expression_evaluation());
    }
}