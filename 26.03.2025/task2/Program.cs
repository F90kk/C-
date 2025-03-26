using System;
using System.Collections.Generic;

public class MyGraph<T>
{
    private Dictionary<T, HashSet<T>> adjacencyList;

    public MyGraph()
    {
        adjacencyList = new Dictionary<T, HashSet<T>>();
    }

    public void AddNode(T node)
    {
        if (!adjacencyList.ContainsKey(node))
        {
            adjacencyList[node] = new HashSet<T>();
        }
    }

    public void RemoveNode(T node)
    {
        if (adjacencyList.ContainsKey(node))
        {
            adjacencyList.Remove(node);
            foreach (var key in adjacencyList.Keys)
            {
                adjacencyList[key].Remove(node);
            }
        }
    }

    public void AddEdge(T from, T to)
    {
        AddNode(from);
        AddNode(to);
        adjacencyList[from].Add(to);
        adjacencyList[to].Add(from);
    }

    public List<T> FindPath(T from, T to)
    {
        if (!adjacencyList.ContainsKey(from) || !adjacencyList.ContainsKey(to))
        {
            return null;
        }

        Queue<T> queue = new Queue<T>();
        Dictionary<T, T> parentMap = new Dictionary<T, T>();
        HashSet<T> visited = new HashSet<T>();

        queue.Enqueue(from);
        visited.Add(from);

        while (queue.Count > 0)
        {
            T currentNode = queue.Dequeue();

            if (currentNode.Equals(to))
            {
                return ReconstructPath(parentMap, from, to);
            }

            foreach (T neighbor in adjacencyList[currentNode])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    parentMap[neighbor] = currentNode;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return null; // Путь не найден
    }

    // Восстановление пути из parentMap
    private List<T> ReconstructPath(Dictionary<T, T> parentMap, T start, T end)
    {
        List<T> path = new List<T>();
        T current = end;

        while (parentMap.ContainsKey(current))
        {
            path.Add(current);
            current = parentMap[current];
        }

        path.Add(start);
        path.Reverse();
        return path;
    }
}

public class GraphProcessor<T>
{
    private MyGraph<T> graph;

    public GraphProcessor(MyGraph<T> graph)
    {
        this.graph = graph;
    }

    // Поиск пути между узлами
    public List<T> FindPath(T from, T to)
    {
        return graph.FindPath(from, to);
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyGraph<string> graph = new MyGraph<string>();

        // Добавление узлов и ребер
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "D");
        graph.AddEdge("C", "D");
        graph.AddEdge("D", "E");

        // Поиск пути между узлами A и E
        GraphProcessor<string> processor = new GraphProcessor<string>(graph);
        List<string> path = processor.FindPath("A", "E");

        if (path != null)
        {
            Console.WriteLine("Путь от A до E:");
            Console.WriteLine(string.Join(" -> ", path));
        }
        else
        {
            Console.WriteLine("Путь от A до E не найден.");
        }

        // Удаление узла D
        graph.RemoveNode("D");

        // Повторный поиск пути между узлами A и E после удаления узла D
        path = processor.FindPath("A", "E");

        if (path != null)
        {
            Console.WriteLine("Путь от A до E после удаления узла D:");
            Console.WriteLine(string.Join(" -> ", path));
        }
        else
        {
            Console.WriteLine("Путь от A до E после удаления узла D не найден.");
        }
    }
}