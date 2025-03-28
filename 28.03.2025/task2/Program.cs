public class Car
{
    public string BodyType { get; set; }
    public string Engine { get; set; }
    public string Transmission { get; set; }
    public string Wheels { get; set; }

    public override string ToString()
    {
        return $"Car [BodyType={BodyType}, Engine={Engine}, Transmission={Transmission}, Wheels={Wheels}]";
    }
}

public interface ICarBuilder
{
    void BuildBodyType();
    void BuildEngine();
    void BuildTransmission();
    void BuildWheels();
    Car GetCar();
}

public class SedanBuilder : ICarBuilder
{
    private Car _car;

    public SedanBuilder()
    {
        _car = new Car();
    }

    public void BuildBodyType()
    {
        _car.BodyType = "Sedan";
    }

    public void BuildEngine()
    {
        _car.Engine = "2.0L Inline-4";
    }

    public void BuildTransmission()
    {
        _car.Transmission = "Automatic";
    }

    public void BuildWheels()
    {
        _car.Wheels = "18-inch Alloy";
    }

    public Car GetCar()
    {
        return _car;
    }
}

public class SUVBuilder : ICarBuilder
{
    private Car _car;

    public SUVBuilder()
    {
        _car = new Car();
    }

    public void BuildBodyType()
    {
        _car.BodyType = "SUV";
    }

    public void BuildEngine()
    {
        _car.Engine = "3.0L V6";
    }

    public void BuildTransmission()
    {
        _car.Transmission = "Automatic";
    }

    public void BuildWheels()
    {
        _car.Wheels = "20-inch Alloy";
    }

    public Car GetCar()
    {
        return _car;
    }
}

public class TruckBuilder : ICarBuilder
{
    private Car _car;

    public TruckBuilder()
    {
        _car = new Car();
    }

    public void BuildBodyType()
    {
        _car.BodyType = "Truck";
    }

    public void BuildEngine()
    {
        _car.Engine = "5.0L V8";
    }

    public void BuildTransmission()
    {
        _car.Transmission = "Manual";
    }

    public void BuildWheels()
    {
        _car.Wheels = "22-inch Alloy";
    }

    public Car GetCar()
    {
        return _car;
    }
}

public class CarDirector
{
    private ICarBuilder _builder;

    public CarDirector(ICarBuilder builder)
    {
        _builder = builder;
    }

    public void SetBuilder(ICarBuilder builder)
    {
        _builder = builder;
    }

    public Car BuildCar()
    {
        _builder.BuildBodyType();
        _builder.BuildEngine();
        _builder.BuildTransmission();
        _builder.BuildWheels();
        return _builder.GetCar();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем строителей
        ICarBuilder sedanBuilder = new SedanBuilder();
        ICarBuilder suvBuilder = new SUVBuilder();
        ICarBuilder truckBuilder = new TruckBuilder();

        // Создаем директора с начальным строителем
        CarDirector director = new CarDirector(sedanBuilder);

        // Строим седан
        Car sedan = director.BuildCar();
        Console.WriteLine("Создан автомобиль:");
        Console.WriteLine(sedan);

        // Изменяем стратегию на SUV
        director.SetBuilder(suvBuilder);
        Car suv = director.BuildCar();
        Console.WriteLine("Создан автомобиль:");
        Console.WriteLine(suv);

        // Изменяем стратегию на Truck
        director.SetBuilder(truckBuilder);
        Car truck = director.BuildCar();
        Console.WriteLine("Создан автомобиль:");
        Console.WriteLine(truck);
    }
}