namespace SOLID.Application.LiskovSubstitutionPrinciple.Antipattern;

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
            // it throws exception for airplain so it breaks princple which says that:
            // "any instance of a derived class should be substituable for an instance of its base class without affecting the correctness of the program"
            vehicle.Drive();
        }
    }
}

public abstract class Vehicle(string name)
{
    public string Name { get; set; } = name;
    public abstract void Drive();

}

public class Car(string name) : Vehicle(name)
{
    public override void Drive()
    {
        Console.WriteLine($"{Name} moves");
    }
}

public class Airplain(string name) : Vehicle(name)
{
    public override void Drive()
    {
        throw new Exception("I'm constructed for flying");
    }
}