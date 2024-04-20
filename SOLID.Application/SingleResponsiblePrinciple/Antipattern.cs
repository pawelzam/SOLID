namespace SOLID.Application.SingleResponsiblePrinciple.Antipattern;

public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}


// Cart should have only one responsibility - manage the collection of products.
// Here it is also responsible for calculating the final price. It mixes two thgings in one class.
// BTW. This class will require modifications if, for example, someone decide to add additional fees to some of the products - so OCP is also broken here.  

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

    // It should not be here. 
    public decimal CalculatePrice()
    {
        return _products.Sum(p => p.Price ?? 0);
    }
}
