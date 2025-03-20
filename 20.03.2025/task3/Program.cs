using System;
using System.Collections.Generic;

public abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract void MakeSound();
}

public sealed class Dog : Animal
{
    public string Breed { get; set; }

    public Dog(string name, int age, string breed) : base(name, age)
    {
        Breed = breed;
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says Woof!");
    }
}

public class Kennel
{
    private Dog[] dogs;

    public Kennel(Dog[] dogs)
    {
        this.dogs = dogs;
    }

    public int CountDogs()
    {
        return dogs.Length;
    }

    public void ListDogs()
    {
        Console.WriteLine("List of Dogs in Kennel:");
        foreach (var dog in dogs)
        {
            Console.WriteLine(dog);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dog[] dogs = new Dog[]
        {
            new Dog("Buddy", 3, "Golden Retriever"),
            new Dog("Max", 5, "Labrador"),
            new Dog("Charlie", 2, "Poodle")
        };

        Kennel kennel = new Kennel(dogs);

        Console.WriteLine("Number of Dogs: " + kennel.CountDogs());

        kennel.ListDogs();

        Console.WriteLine("\nDogs making sounds:");
        foreach (var dog in dogs)
        {
            dog.MakeSound();
        }
    }
}