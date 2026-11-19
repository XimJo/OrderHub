using System.Linq;
using System.Collections.Generic;
using OrderHub.Domain;

namespace OrderHub.Services;

public class ReportService
{

    public static List<string> ExpensiveProducts(IEnumerable<Product> products, decimal threshold)
    {
        return products
            .Where(p => p.Price > threshold)
            .OrderBy(p => p.Price)
            .Select(p => $"{p.Name} - {p.Price:0.00} Р")
            .ToList();
    }


    public static int CountExpensive(IEnumerable<Product> products, decimal threshold)
        => products.Count(p => p.Price > threshold);

    // ЗАДАЧА: Any
    public static bool HasVeryExpensive(IEnumerable<Product> products, decimal threshold)
        => products.Any(p => p.Price > threshold);


    public static bool AllInStock(IEnumerable<Product> products)
        => products.All(p => p.Price > 0);


    public static Product? Cheapest(IEnumerable<Product> products)
        => products.OrderBy(p => p.Price).FirstOrDefault();

        public class CategorySummary
{
    public string Category { get; set; } = "";
    public int Count { get; set; }
    public decimal AveragePrice { get; set; }
}



    public static List<CategorySummary> SummarizeByCategory(IEnumerable<Product> products)
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
    public static string MostExpensiveCategory(IEnumerable<Product> products)
    {
        return SummarizeByCategory(products)
            .OrderByDescending(s => s.AveragePrice)
            .First().Category;
    }


    public static List<string> CategoriesWithAtLeast(IEnumerable<Product> products, int minCount)
    {
        return products
            .GroupBy(p => p.Category)
            .Where(g => g.Count() >= minCount)
            .Select(g => g.Key)
            .ToList();
    }

 
    public static List<string> TopCustomers(
        IEnumerable<Customer> customers,
        IEnumerable<Order> orders,
        int topCount)
    {
        return customers
            .Join(orders,
                  c => c.Name,
                  o => o.CustomerName,
                  (c, o) => new { c.Name, o.Price })
            .GroupBy(x => x.Name)
            .Select(g => new { Name = g.Key, Total = g.Sum(x => x.Price) })
            .OrderByDescending(x => x.Total)
            .Take(topCount)
            .Select(x => $"{x.Name} - {x.Total:0.00} ₽")
            .ToList();
    }

    //общая выручка по заказам заданного года
    public static decimal RevenueByYear(IEnumerable<Order> orders, int year)
        => orders.Where(o => o.CreatedAt.Year == year).Sum(o => o.Price);

    public static string? CustomerWithMostOrders(IEnumerable<Order> orders)
    {
        return orders
            .GroupBy(o => o.CustomerName)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();
    }

    public static List<Order> OrdersAboveAverage(IEnumerable<Order> orders)
    {
        var list = orders.ToList();
        if (list.Count == 0) return new List<Order>();

        decimal avg = list.Average(o => o.Price);
        return list.Where(o => o.Price > avg).ToList();
    }
}



