using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name}, {Age} years old";
    }
}

public static class ArrayOperations
{
    public static Dictionary<int, List<Person>> GroupByAge(Person[] people)
    {
        var groupedByAge = new Dictionary<int, List<Person>>();

        foreach (var person in people)
        {
            if (!groupedByAge.ContainsKey(person.Age))
            {
                groupedByAge[person.Age] = new List<Person>();
            }
            groupedByAge[person.Age].Add(person);
        }

        return groupedByAge;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person[] people = new Person[]
        {
            new Person("Alice", 25),
            new Person("Bob", 30),
            new Person("Charlie", 25),
            new Person("David", 35),
            new Person("Eve", 30)
        };

        var groupedByAge = ArrayOperations.GroupByAge(people);

        Console.WriteLine("People Grouped by Age:");
        foreach (var kvp in groupedByAge)
        {
            Console.WriteLine($"Age {kvp.Key}:");
            foreach (var person in kvp.Value)
            {
                Console.WriteLine($"  {person}");
            }
        }
    }
}