double[] arr = new double[] { 1.12, -3.123, -4.21, -4.54, 2.12 };
double min_num = arr[0];
for (int i = 0; i < arr.Length; i++)
{
    if (min_num > arr[i])
    {
        min_num = arr[i];
    }
}
Console.WriteLine(min_num);