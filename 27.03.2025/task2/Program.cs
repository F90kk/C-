using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Car
{
    public string Brand { get; set; }
    public int Year { get; set; }

    public override string ToString()
    {
        return $"{Brand},{Year}";
    }
}

public class CarFileWriter
{
    public const string FilePath = "file.data";

    public void WriteFilteredCars(List<Car> cars, int minYear)
    {
        using (StreamWriter writer = new StreamWriter(FilePath, false, Encoding.UTF8))
        {
            foreach (var car in cars)
            {
                if (car.Year > minYear)
                {
                    writer.WriteLine(car);
                }
            }
        }
        Console.WriteLine($"Автомобили, выпущенные после {minYear}, записаны в файл {FilePath}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>
        {
            new Car { Brand = "Toyota", Year = 2015 },
            new Car { Brand = "Ford", Year = 2010 },
            new Car { Brand = "BMW", Year = 2020 },
            new Car { Brand = "Audi", Year = 2018 }
        };

        CarFileWriter carFileWriter = new CarFileWriter();

        carFileWriter.WriteFilteredCars(cars, 2015);

        if (File.Exists(CarFileWriter.FilePath))
        {
            Console.WriteLine("\nСодержимое файла file.data:");
            string[] lines = File.ReadAllLines(CarFileWriter.FilePath);
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("Файл file.data не найден.");
        }
    }
}