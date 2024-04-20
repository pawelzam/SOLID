namespace SOLID.Application.LiskovSubstitutionPrinciple;
class Program()
{
    public static void Main()
    {
        var vehicles = new List<Vehicle>
        {
            new Car("Audi"),
            new Airplain("Boeing")
        };

        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
    }
}

public abstract class Vehicle(string name)
{
    public string Name { get; set; } = name;
    public abstract void Move();
    
}

public class Car(string name) : Vehicle(name)
{
    public override void Move()
    {
        Console.WriteLine($"{Name} moves");
    }
}

public class Airplain(string name) : Vehicle(name)
{
    public override void Move()
    {
        Console.WriteLine($"{Name} moves");
    }
}
