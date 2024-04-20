namespace SOLID.Application.InterfaceSegragationPrinciple;

static class Program
{
    static void Main()
    {
        var logger = new Logger();
        var priceCalculator = new PriceCalculator(new AdditionalFeeProvider());
        var cart = new Cart();
        cart.AddProduct(new Whisky());
        cart.AddProduct(new Bourbon());
        var total = priceCalculator.CalculatePrice(cart);
        logger.Log($"Cart total is {total}");
    }
}

#region Interfaces

public interface ICart
{
    void AddProduct(Product product);
    void TryRemoveProduct(Product product);
    Product? TryGetProduct(int id);
}

public interface IAdditionalFeeProvider
{
    decimal GetProductFees(Product product);
}

public interface IPriceCalculator
{
    decimal CalculatePrice(Cart cart);
}

public interface ILogger
{
    void Log(string message);
}

#endregion

#region Implementation

public class AdditionalFeeProvider : IAdditionalFeeProvider
{
    public decimal GetProductFees(Product product)
    {
        return product is Bourbon ? 10 : 12;
    }
}

public class PriceCalculator(IAdditionalFeeProvider additionalFeeProvider) : IPriceCalculator
{
    private readonly IAdditionalFeeProvider _additionalFeeProvider = additionalFeeProvider;

    public decimal CalculatePrice(Cart cart)
    {
        return cart.Products.Sum(p => (p.Price ?? 0) + _additionalFeeProvider.GetProductFees(p));
    }
}

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class Cart : ICart
{
    public List<Product> Products { get; private set; } = [];


    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void TryRemoveProduct(Product product)
    {
        if (!Products.Contains(product))
        {
            throw new Exception("Product not found");
        }

        Products.Remove(product);
    }

    public Product? TryGetProduct(int id)
    {
        return Products.FirstOrDefault(p => p.Id == id);
    }
}

#endregion
