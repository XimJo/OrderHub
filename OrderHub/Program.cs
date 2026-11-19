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