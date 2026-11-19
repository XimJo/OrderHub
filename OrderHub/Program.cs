using System;
using System.Linq;
using System.Collections.Generic;
using OrderHub.Services;
using OrderHub.Domain; 


var service = new OrderService();

service.CreateOrder("Иванов", "Клавиатура", 5490m);
service.CreateOrder("Петрова", "Монитор", 18990m);
service.CreateOrder("Сидоров", "Мышь", 1290m);

service.ProcessNext();
service.ProcessNext();

service.PrintAllOrders();
service.PrintPendingQueue();
service.PrintRecentActions();

Console.WriteLine("\n==========================================\n");


IEnumerable<Order> orders = OrderStream.Orders();
Console.WriteLine("После вызова метода");

foreach (var order in orders.Take(5))
    Console.WriteLine($"  {order}");

Console.WriteLine();

Console.WriteLine("Expensive(10, 10000):");
foreach (var order in OrderStream.Expensive(10, 10000m))
    Console.WriteLine($"  {order}");

Console.WriteLine();

Console.WriteLine("Orders().ToList() без Take зависнет – последовательность бесконечна");