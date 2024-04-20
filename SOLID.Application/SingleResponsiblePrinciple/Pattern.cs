namespace SOLID.Application.SingleResponsiblePrinciple;

public interface IAdditionalFeeProvider
{
    decimal GetProductFees(Product product);
}

public interface IPriceCalculator
{
    decimal CalculatePrice(IEnumerable<Product> products);
}

public class PriceCalculator(IAdditionalFeeProvider additionalFeeProvider) : IPriceCalculator
{
    private readonly IAdditionalFeeProvider _additionalFeeProvider = additionalFeeProvider;

    public decimal CalculatePrice(IEnumerable<Product> products)
    {
        return products.Sum(p => (p.Price ?? 0) + _additionalFeeProvider.GetProductFees(p));
    }
}

public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}

public class Cart
{
    private readonly List<Product> _products;

    public Cart() => _products = [];

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public void Remove(Product product)
    {
        if (!_products.Contains(product))
        {
            throw new Exception("Product not found");
        }

        _products.Remove(product);
    }

    public Product? TryGet(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
}
