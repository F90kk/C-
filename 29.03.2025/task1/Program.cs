public interface IFuelType
{
    string GetEnergySource();
}

public class Gasoline : IFuelType
{
    public string GetEnergySource()
    {
        return $"Бензин";
    }
}

public class Diesel : IFuelType
{
    public string GetEnergySource()
    {
        return $"Дизель";
    }
}

public class Electric : IFuelType
{
    public string GetEnergySource()
    {
        return $"Электричество";
    }
}

public abstract class FuelFactory
{
    public abstract IFuelType CreateFuel();
}

public class GasolineFactory : FuelFactory
{
    public override IFuelType CreateFuel()
    {
        return new Gasoline();
    }
}

public class DieselFactory : FuelFactory
{
    public override IFuelType CreateFuel()
    {
        return new Diesel();
    }
}

public class ElectricFactory : FuelFactory
{
    public override IFuelType CreateFuel()
    {
        return new Electric();
    }
}

class Program
{
    static void Main(string[] args)
    {
        FuelFactory gasolineFactory = new GasolineFactory();
        FuelFactory dieselFactory = new DieselFactory();
        FuelFactory electricFactory = new ElectricFactory();

        IFuelType gasoline = gasolineFactory.CreateFuel();
        IFuelType diesel = dieselFactory.CreateFuel();
        IFuelType electric = electricFactory.CreateFuel();

        Console.WriteLine(gasoline.GetEnergySource());
        Console.WriteLine(diesel.GetEnergySource());   
        Console.WriteLine(electric.GetEnergySource());
    }
}