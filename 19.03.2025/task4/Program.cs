int wagons = 20;
int seatsPerWagon = 36;
int[,] tickets = new int[wagons, seatsPerWagon];

Random rand = new Random();
for (int i = 0; i < wagons; i++)
{
    for (int j = 0; j < seatsPerWagon; j++)
    {
        tickets[i, j] = rand.Next(0, 2);
    }
}

Console.WriteLine("Исходный массив билетов:");
for (int i = 0; i < wagons; i++)
{
    for (int j = 0; j < seatsPerWagon; j++)
    {
        Console.Write(tickets[i, j]);
    }
    Console.WriteLine();
}

bool hasFreeSeats = false;
for (int i = 0; i < wagons; i++)
{
    for (int j = 0; j < seatsPerWagon; j++)
    {
        if (tickets[i, j] == 0)
        {
            hasFreeSeats = true;
            break;
        }
    }
    if (hasFreeSeats)
    {
        break;
    }
}

if (hasFreeSeats)
{
    Console.WriteLine("В поезде есть свободные места.");
}
else
{
    Console.WriteLine("В поезде свободных мест нет.");
}