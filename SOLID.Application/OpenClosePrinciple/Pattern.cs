namespace SOLID.Application.OpenClosePrinciple;
public interface IShape
{
    double CalculateArea();
}

public class Rectangle : IShape
{
    public double Height { get; set; }
    public double Width { get; set; }

    public double CalculateArea()
    {
        return Height * Width;
    }
}

public class Circle : IShape
{
    public double Radius { get; set; }

    public double CalculateArea()
    {
        return Math.Pow(Radius, 2) * Math.PI;
    }
}

public class AreaCalculator
{
    public double TotalArea(IShape[] shapes)
    {
        return shapes.Sum(p => p.CalculateArea());
    }
}
