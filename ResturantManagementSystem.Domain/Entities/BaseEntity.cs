public abstract class BaseEntity
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; private set; } = DateTime.Now;

    public bool IsDeleted { get; private set; }

    public void Delete()
    {
        if (IsDeleted)
        {
            throw new InvalidOperationException("Item is already deleted.");
        }    

        IsDeleted = true;
    }
}
