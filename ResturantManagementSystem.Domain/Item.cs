public abstract class Item
{
    public int Id { get; protected set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsDeleted { get; private set; }

    protected Item(string name, decimal price)
    {
        SetName(name);
        SetPrice(price);
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        if (name.Length > 150)
            throw new ArgumentException("Name too long.");

        Name = name;
    }

    public void SetPrice(decimal price)
    {
        if (price < 0)
            throw new ArgumentException("Price cannot be negative.");

        Price = price;
    }

    public void Delete()
    {
        if (IsDeleted)
            throw new InvalidOperationException("Item is already deleted.");

        IsDeleted = true;
    }
}
