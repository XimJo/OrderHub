using System.Collections.Generic;
using System.Linq;

namespace OrderHub.Services;

public class WarehouseService
{
    private readonly Dictionary<string, int> stock = [];

    public void Receive(string productName, int quantity)
    {
        if (stock.TryGetValue(productName, out int existing))
        {
            stock[productName] = existing + quantity;
        }
        else
        {
            stock[productName] = quantity;
        }

        Console.WriteLine($"Поступление: {productName} +{quantity}, итого {stock[productName]}");
    }

    public bool Sell(string productName, int quantity)
    {
        if (!stock.TryGetValue(productName, out int existing))
        {
            Console.WriteLine($"Товара «{productName}» нет на складе");
            return false;
        }

        if (existing < quantity)
        {
            Console.WriteLine($"Недостаточно товара «{productName}»: запрошено {quantity}, есть {existing}");
            return false;
        }

        int remaining = existing - quantity;

        if (remaining == 0)
        {
            stock.Remove(productName);
            Console.WriteLine($"Товар «{productName}» продан полностью и снят с учёта");
        }
        else
        {
            stock[productName] = remaining;
            Console.WriteLine($"Продажа: {productName} -{quantity}, остаток {remaining}");
        }

        return true;
    }

    public bool TryGetStock(string productName, out int quantity)
    {
        if (stock.TryGetValue(productName, out quantity))
            return true;

        quantity = 0;
        return false;
    }

    public void PrintStock()
    {
        // ЗАДАЧА: переберите склад через foreach по KeyValue
        Console.WriteLine("Склад:");
        foreach (var pair in stock.OrderBy(p => p.Key))
            Console.WriteLine($"  {pair.Key}: {pair.Value}");
    }
}