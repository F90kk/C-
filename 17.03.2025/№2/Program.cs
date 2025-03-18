string num = Console.ReadLine();
int sum = 0;

for (int i = 0; i < num.Length; i++)
{
    int digit = int.Parse(num[i].ToString());
    sum += digit;
}

Console.WriteLine($"Сумма чисел: {sum}");



