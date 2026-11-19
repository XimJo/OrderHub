using OrderHub.Services;

var service = new OrderService();

service.CreateOrder("Иванов", "Клавиатура", 5490m);
service.CreateOrder("Петрова", "Монитор", 18990m);
service.CreateOrder("Сидоров", "Мышь", 1290m);

service.ProcessNext();
service.ProcessNext();

service.PrintAllOrders();       // Count = 3
service.PrintPendingQueue();    // Count = 1, Peek = третий заказ (Сидоров)
service.PrintRecentActions();   // сверху — обработка второго заказа
service.InitHistory(
    service.CreateOrder("Иванов", "Клавиатура", 5490m),
    service.CreateOrder("Петрова", "Монитор", 18990m));

service.PlaceOrderAfterCurrent(service.CreateOrder("Сидоров", "Мышь", 1290m));
service.PrintHistory();

Console.WriteLine(service.TryFindOrder("Иванов", out var found) + " " + found);
Console.WriteLine(service.TryFindOrder("Нет такого", out _)); // false

var warehouse = new WarehouseService();

warehouse.Receive("Клавиатура", 10);
warehouse.Receive("Клавиатура", 5);   // одна запись, количество 15
warehouse.Receive("Монитор", 3);
warehouse.Sell("Монитор", 1);
warehouse.Sell("Монитор", 99);        // предупреждение, остаток не меняется
warehouse.Sell("Проектор", 1);        // товара нет, без исключения
warehouse.PrintStock();