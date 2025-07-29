namespace ResturantManagementSystem.Domain.Entities
{
    public sealed class Food : Item
    {
        public Food(string name, decimal price) : base(name, price) 
        {
        }
    }
}
