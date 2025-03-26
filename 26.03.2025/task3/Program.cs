using System;
using System.Collections.Generic;

public interface IStack<T>
{
    void Push(T item);
    T Pop();
    T Peek();
}

public class SimpleStack<T> : IStack<T>
{
    private Stack<T> stack;

    public SimpleStack()
    {
        stack = new Stack<T>();
    }

    public void Push(T item)
    {
        stack.Push(item);
    }

    public T Pop()
    {
        if (stack.Count == 0)
        {
            throw new InvalidOperationException("Стек пуст.");
        }
        return stack.Pop();
    }

    public T Peek()
    {
        if (stack.Count == 0)
        {
            throw new InvalidOperationException("Стек пуст.");
        }
        return stack.Peek();
    }

    public bool IsEmpty()
    {
        return stack.Count == 0;
    }

    public IEnumerable<T> GetElements()
    {
        return stack;
    }
}

public class StackManager<T>
{
    private IStack<T> stack;

    public StackManager(IStack<T> stack)
    {
        this.stack = stack;
    }

    public void PrintStack()
    {
        if (stack.IsEmpty())
        {
            Console.WriteLine("Стек пуст.");
            return;
        }

        foreach (var item in stack.GetElements())
        {
            Console.WriteLine(item);
        }
    }

    public bool IsEmpty()
    {
        return stack.IsEmpty();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IStack<int> stack = new SimpleStack<int>();
        StackManager<int> stackManager = new StackManager<int>(stack);

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        stackManager.PrintStack();

        Console.WriteLine($"\nСтек пуст: {stackManager.IsEmpty()}");

        Console.WriteLine($"\nВерхний элемент: {stack.Peek()}");

        Console.WriteLine($"\nУдалённый элемент: {stack.Pop()}");

        stackManager.PrintStack();

        Console.WriteLine($"\nСтек пуст: {stackManager.IsEmpty()}");
    }
}