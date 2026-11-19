namespace OrderHub.Domain;

public class Product : IComparable<Product>
{
<<<<<<< HEAD

=======
    // конструктор с параметрами 
>>>>>>> be9b470ab507a478acfb306240730fcd0f0ad789
    public Product(string name, decimal price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }

<<<<<<< HEAD

=======
>>>>>>> be9b470ab507a478acfb306240730fcd0f0ad789
    public string Name { get; private set; } = "";
    public decimal Price { get; private set; }
    public string Category { get; private set; } = "";

    public int CompareTo(Product? other)
    {
<<<<<<< HEAD

=======
>>>>>>> be9b470ab507a478acfb306240730fcd0f0ad789
        if (other is null) return 1;
        return Price.CompareTo(other.Price);
    }

    public override string ToString() => $"{Name} - {Price:0.00} Р ({Category})";
}

<<<<<<< HEAD

=======
>>>>>>> be9b470ab507a478acfb306240730fcd0f0ad789
public class NameComparer : IComparer<Product>
{
    public int Compare(Product? a, Product? b)
        => string.Compare(a?.Name, b?.Name, StringComparison.Ordinal);
}

<<<<<<< HEAD

=======
>>>>>>> be9b470ab507a478acfb306240730fcd0f0ad789
public class PriceDescComparer : IComparer<Product>
{
    public int Compare(Product? a, Product? b)
        => b!.Price.CompareTo(a!.Price);
}