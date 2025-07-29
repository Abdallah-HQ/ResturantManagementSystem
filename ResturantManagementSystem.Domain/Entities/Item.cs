using ResturantManagementSystem.Domain.Shared.Constants;

public abstract class Item : BaseEntity
{
    public string Name { get; private set; }
    
    public decimal Price { get; private set; }

    protected Item(string name, decimal price)
    {
        SetName(name);
        SetPrice(price);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(ItemConstants.NameCantBeEmpty);
        }

        if (name.Length > 150)
        {
            throw new ArgumentException(ItemConstants.NameTooLong);
        }

        Name = name;
    }

    public void SetPrice(decimal price)
    {
        if (price < 0)
        {
            throw new ArgumentException(ItemConstants.PriceCantBeNegative);
        }

        Price = price;
    }
}
