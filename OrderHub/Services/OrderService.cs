using OrderHub.Domain;
namespace OrderHub.Services;

public class OrderService
{
    // ЗАДАЧА: объявите три коллекции с точной сигнатурой
    private readonly List<Order> allOrders = new();
    private readonly Queue<Order> pendingQueue = new();
    private readonly Stack<string> undoHistory = new();

    private int nextId = 1;

    public Order CreateOrder(string customerName, string productName, decimal price)
    {
        // 1 
        var order = new Order(nextId++, customerName, productName, price, DateTime.Now);

        //  2 добавьте заказ
        allOrders.Add(order);

        // 3 добавьте тот же заказ в pendingQueue методом Enqueue
        pendingQueue.Enqueue(order);

        //4 запишите в undoHistory описание действия для возможной отмены
        undoHistory.Push($"Создан заказ {order.Id} для {customerName}");

        //5 верните созданный заказ
        return order;
    }

    public Order? ProcessNext()
    {
        // 1 если pendingQueue пуст – вернётся null
        if (pendingQueue.Count == 0)
            return null;

        //2 извлеките заказ из очереди методом Dequeue 
        var order = pendingQueue.Dequeue();

        //3 запишите в undoHistory обработаный заказ
        undoHistory.Push($"Обработан заказ {order.Id} для {order.CustomerName}");

        //4 
        Console.WriteLine($"Обработан заказ: {order}");

        //5 обработанный заказ
        return order;
    }

    public bool UndoLastAction()
    {
        //1 если undoHistory пуст – вернётся false
        if (undoHistory.Count == 0)
            return false;

        //2 извлекается последнее действие методом Pop
        var action = undoHistory.Pop();

        //3 выводится $"Отменено действие: {action}" и возвращается true
        Console.WriteLine($"Отменено действие: {action}");
        return true;
    }

    //1 три метода-отчёта, используя foreach
    public void PrintAllOrders()
    {
        Console.WriteLine($"Все заказы (всего {allOrders.Count}):");
        foreach (var order in allOrders)
            Console.WriteLine($"  {order}");
    }

    public void PrintPendingQueue()
    {
        Console.WriteLine($"В очереди ожидает: {pendingQueue.Count}");
        if (pendingQueue.Count > 0)
            Console.WriteLine($"  Первый в очереди: {pendingQueue.Peek()}");
    }

    public void PrintRecentActions()
    {
        Console.WriteLine("История действий (от последнего к первому):");
        foreach (var action in undoHistory)
            Console.WriteLine($"  {action}");
    }
}