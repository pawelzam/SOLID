using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Application.InterfaceSegragationPrinciple;
public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}

public class Whisky : Product
{
}

public class Bourbon : Product
{
}

