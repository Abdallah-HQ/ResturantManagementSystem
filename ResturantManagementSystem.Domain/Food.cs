namespace ResturantManagementSystem.Domain
{
    public sealed class Food : Item
    {
        private static int _autoFoodsIds = 0;
        public Food(string name, decimal price) : base(name, price) 
        {
            this.Id = ++_autoFoodsIds;
        }
    }
}
