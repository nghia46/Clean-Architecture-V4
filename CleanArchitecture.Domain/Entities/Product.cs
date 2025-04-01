namespace CleanArchitecture.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Product(string name, decimal price, int stock)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Stock = stock;
        CreatedAt = DateTime.UtcNow + TimeSpan.FromHours(7); // UTC+7
        UpdatedAt = DateTime.UtcNow + TimeSpan.FromHours(7);
    }
}

