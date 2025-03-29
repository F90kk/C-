public interface ICommand
{
    void Execute();
}

public class StartIrrigationCommand : ICommand
{
    private IrrigationSystem _system; 

    public StartIrrigationCommand(IrrigationSystem system)
    {
        _system = system; 
    }

    public void Execute()
    {
        _system.Start(); 
    }
}

public class StopIrrigationCommand : ICommand
{
    private IrrigationSystem _system; 

    public StopIrrigationCommand(IrrigationSystem system)
    {
        _system = system; 
    }

    public void Execute()
    {
        _system.Stop(); 
    }
}

public class IrrigationSystem
{
    public void Start()
    {
        Console.WriteLine("Полив начат.");
    }

    public void Stop()
    {
        Console.WriteLine("Полив остановлен."); 
    }
}

// 5. Инициатор: контроллер орошения
public class IrrigationController
{
    private ICommand _startCommand; 
    private ICommand _stopCommand;  

    public void SetStartCommand(ICommand startCommand)
    {
        _startCommand = startCommand; 
    }

    public void SetStopCommand(ICommand stopCommand)
    {
        _stopCommand = stopCommand; 
    }

    public void StartIrrigation()
    {
        _startCommand?.Execute(); 
    }

    public void StopIrrigation()
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        IrrigationSystem irrigationSystem = new IrrigationSystem();

        ICommand startCommand = new StartIrrigationCommand(irrigationSystem);
        ICommand stopCommand = new StopIrrigationCommand(irrigationSystem);

        IrrigationController controller = new IrrigationController();
        controller.SetStartCommand(startCommand);
        controller.SetStopCommand(stopCommand);

        Console.WriteLine("Запуск полива:");
        controller.StartIrrigation();

        Console.WriteLine("\nОстановка полива:");
        controller.StopIrrigation();
    }
}