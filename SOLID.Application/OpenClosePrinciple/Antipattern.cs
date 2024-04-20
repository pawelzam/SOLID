namespace SOLID.Application.OpenClosePrinciple.Antipatern;


public interface IShape
{
}

public class Rectangle : IShape
{
    public double Height { get; set; }
    public double Width { get; set; }
}

public class Circle: IShape
{
    public double Radius { get; set; }
}

public class AreaCalculator
{
    public double TotalArea(IShape[] shapes)
    {
        double area = 0;
        foreach (var shape in shapes)
        {
            var rectangle = shape as Rectangle;
            if(rectangle != null)
            {
                area += rectangle.Height * rectangle.Width;
            }

            var circle = shape as Circle;
            if(circle != null)
            {
                area += Math.Pow(circle.Radius, 2) * Math.PI;
            }

            // Every next shape require modification in this method
        }
        return area;
    }
}