using System.Linq;
using System.Collections.Generic;
using OrderHub.Domain;

namespace OrderHub.Services;

public class ReportService
{

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

    // ЗАДАЧА: Any
    public bool HasVeryExpensive(IEnumerable<Product> products, decimal threshold)
        => products.Any(p => p.Price > threshold);


    public bool AllInStock(IEnumerable<Product> products)
        => products.All(p => p.Price > 0);


    public Product? Cheapest(IEnumerable<Product> products)
        => products.OrderBy(p => p.Price).FirstOrDefault();

        public class CategorySummary
{
    public string Category { get; set; } = "";
    public int Count { get; set; }
    public decimal AveragePrice { get; set; }
}



    public List<CategorySummary> SummarizeByCategory(IEnumerable<Product> products)
    {
        return products
            .GroupBy(p => p.Category)
            .Select(g => new CategorySummary
            {
                Category = g.Key,
                Count = g.Count(),
                AveragePrice = g.Average(p => p.Price)
            })
            .OrderByDescending(s => s.Count)
            .ToList();
    }

    // самая дорогая категория по средней цене
    public string MostExpensiveCategory(IEnumerable<Product> products)
    {
        return SummarizeByCategory(products)
            .OrderByDescending(s => s.AveragePrice)
            .First().Category;
    }


    public List<string> CategoriesWithAtLeast(IEnumerable<Product> products, int minCount)
    {
        return products
            .GroupBy(p => p.Category)
            .Where(g => g.Count() >= minCount)
            .Select(g => g.Key)
            .ToList();
    }
}

