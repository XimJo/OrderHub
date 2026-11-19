namespace OrderHub.Domain;

public class Order
{
    // 1
    public Order(int id, string customerName, string productName, decimal price, DateTime createdAt)
    {
        Id = id;
        CustomerName = customerName;
        ProductName = productName;
        Price = price;
        CreatedAt = createdAt;
    }

    // 2
    public int Id { get; }
    public string CustomerName { get; }
    public string ProductName { get; }
    public decimal Price { get; }
    public DateTime CreatedAt { get; }

    // 3
    public override string ToString()
        => $"#{Id} {CustomerName} – {ProductName} {Price:N2} ₽ ({CreatedAt:dd.MM.yyyy})";
}