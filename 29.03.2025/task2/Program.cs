using System.Security.AccessControl;

public interface IDataProcessor
{
    string ProcessData(string data);
}

public class BasicDataProcessor : IDataProcessor
{
    public string ProcessData(string data)
    {
        return data;
    }
}

public abstract class DataProcessorDecorator : IDataProcessor
{
    protected IDataProcessor _processor;

    public DataProcessorDecorator(IDataProcessor processor)
    {
        _processor = processor;
    }

    public abstract string ProcessData(string data);
}

public class EncryptionDecorator : DataProcessorDecorator
{
    public EncryptionDecorator(IDataProcessor processor) : base(processor)
    {
    }

    public override string ProcessData(string data)
    {
        string processedData = _processor.ProcessData(data);
        return $"Зашифровано: {processedData}";
    }
}

public class ComperssionDecorator : DataProcessorDecorator
{
    public ComperssionDecorator(IDataProcessor processor) : base(processor)
    {
    }

    public override string ProcessData(string data)
    {
        string processedData = _processor.ProcessData(data);
        return $"Сжато: {processedData}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        IDataProcessor processor = new BasicDataProcessor();

        processor = new EncryptionDecorator(processor);
        
        processor = new ComperssionDecorator(processor);

        string inputData = "Конфиденциальные данные";
        string result = processor.ProcessData(inputData);

        Console.WriteLine(result);
    }
}