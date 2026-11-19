using System.Linq;
using System.Collections.Generic;
using OrderHub.Domain;

namespace OrderHub.Services;

public class ReportService
{
    // ЗАДАЧА: Where → OrderBy → Select → ToList
    public List<string> ExpensiveProducts(IEnumerable<Product> products, decimal threshold)
    {
        return products
            .Where(p => p.Price > threshold)
            .OrderBy(p => p.Price)
            .Select(p => $"{p.Name} - {p.Price:0.00} Р")
            .ToList();
    }

    public int CountExpensive(IEnumerable<Product> products, decimal threshold)
        => products.Count(p => p.Price > threshold);

    public bool HasVeryExpensive(IEnumerable<Product> products, decimal threshold)
        => products.Any(p => p.Price > threshold);

    // ЗАДАЧА: All – все товары в наличии (в учебном каталоге – цена > 0)
    public bool AllInStock(IEnumerable<Product> products)
        => products.All(p => p.Price > 0);

    // ЗАДАЧА: самый дешёвый товар через OrderBy/FirstOrDefault
    public Product? Cheapest(IEnumerable<Product> products)
        => products.OrderBy(p => p.Price).FirstOrDefault();
}