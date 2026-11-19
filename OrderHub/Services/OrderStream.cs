using System.Collections.Generic;
using OrderHub.Domain;

namespace OrderHub.Services;

public static class OrderStream
{
    public static IEnumerable<Order> Orders()
    {
        int n = 0;
        string[] customers = { "Иванов", "Петрова", "Сидоров" };

        while (true)
        {
            n++;

            Console.WriteLine($"Готовлю заказ #{n}");

            var order = new Order(
                n,
                customers[(n - 1) % customers.Length],
                $"Товар-{n}",
                1000m + n * 500m,
                DateTime.Now);

            yield return order;
        }
    }

    public static IEnumerable<Order> Expensive(int limit, decimal threshold)
    {
        int n = 0;
        string[] customers = { "Иванов", "Петрова", "Сидоров" };

        for (int i = 1; i <= limit; i++)
        {
            n++;
            decimal price = 1000m + i * 500m;

            if (price < threshold) continue;

            yield return new Order(
                n,
                customers[(n - 1) % customers.Length],
                $"Товар-{n}",
                price,
                DateTime.Now);
        }
    }
}