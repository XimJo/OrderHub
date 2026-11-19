using System.Collections.Generic;
using OrderHub.Domain;

namespace OrderHub.Services;

public class CatalogService
{
    private readonly List<Product> products = new();

    public void AddProduct(string name, decimal price, string category)
    {
        products.Add(new Product(name, price, category));
    }

    public void PrintSortedByNaturalOrder()
    {
        products.Sort();
        PrintAll("Сортировка по цене (IComparable):");
    }

    public void PrintSortedByName()
    {
        products.Sort(new NameComparer());
        PrintAll("Сортировка по названию (IComparer):");
    }

    public void PrintSortedByNameLength()
    {
        products.Sort((a, b) => a.Name.Length.CompareTo(b.Name.Length));
        Console.WriteLine("Сортировка по длине названия (лямбда, тип Product не менялся):");
        foreach (var p in products)
            Console.WriteLine($"  {p}");
    }

    public void PrintAll(string? header = null)
    {
        if (header != null) Console.WriteLine(header);
        foreach (var p in products)
            Console.WriteLine($"  {p}");
    }
}