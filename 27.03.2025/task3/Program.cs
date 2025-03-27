using System;
using System.Collections.Generic;
using System.Linq;


public class Student
{
    public string Name { get; set; }
    public double Score { get; set; }

    public Student(string name, double score)
    {
        Name = name;
        Score = score;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Score: {Score}";
    }
}



public class StudentFileReader
{
    private readonly string _filePath;

    public StudentFileReader(string filePath)
    {
        _filePath = filePath;
    }

    public List<Student> ReadStudents()
    {
        var students = new List<Student>();

        using (var reader = new StreamReader(_filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');
                if (parts.Length == 2 && double.TryParse(parts[1], out double score))
                {
                    students.Add(new Student(parts[0].Trim(), score));
                }
            }
        }

        return students;
    }
}


public class StudentProcessor
{
    private readonly List<Student> _students;

    public StudentProcessor(List<Student> students)
    {
        _students = students;
    }

    public double CalculateAverageScore()
    {
        if (_students.Count == 0) return 0;
        return _students.Average(s => s.Score);
    }

    public List<Student> GetTopStudents(int count)
    {
        return _students.OrderByDescending(s => s.Score).Take(count).ToList();
    }

    public void AnalyzePerformance()
    {
        var averageScore = CalculateAverageScore();
        Console.WriteLine($"Average Score: {averageScore:F2}");

        var topStudents = GetTopStudents(3); 
        Console.WriteLine("Top Students:");
        foreach (var student in topStudents)
        {
            Console.WriteLine(student);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "file.data";
        var reader = new StudentFileReader(filePath);
        var students = reader.ReadStudents();

        var processor = new StudentProcessor(students);
        processor.AnalyzePerformance();
    }
}