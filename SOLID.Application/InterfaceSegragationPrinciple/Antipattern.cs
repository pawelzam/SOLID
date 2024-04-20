namespace SOLID.Application.InterfaceSegragationPrinciple.Antipattern;

static class Program
{
    static void Main()
    {
        var cart = new Cart();
        cart.AddProduct(new Whisky());
        cart.AddProduct(new Bourbon());
        var total = cart.CalculatePrice();
        cart.WriteLog($"Cart total is {total}");
    }
}

public interface ICart
{
    void AddProduct(Product product);
    void TryRemoveProduct(Product product);
    Product? TryGetProduct(int id);
    decimal CalculatePrice();
    void WriteLog(string message);
}

public class Cart : ICart
{
    private readonly List<Product> _products = [];


    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void TryRemoveProduct(Product product)
    {
        if (!_products.Contains(product))
        {
            throw new Exception("Product not found");
        }

        _products.Remove(product);
    }

    public decimal CalculatePrice()
    {
        return _products.Sum(p => p.Price ?? 0);
    }

    public Product? TryGetProduct(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public void WriteLog(string message)
    {
        File.AppendAllText(@"c:\logs.txt", message);
    }
}