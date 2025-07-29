using ResturantManagementSystem.Domain.Shared.Constants;

namespace ResturantManagementSystem.Domain.Entities
{
    public sealed class Drink : Item
    {
        
        public DrinkType Type { get; private set; }
        
        public Drink(string name, decimal price, DrinkType type) : base(name, price)
        {
            SetType(type);
        }

        public void SetType(DrinkType type)
        {
            if (!Enum.IsDefined(typeof(DrinkType), type))
            {
                throw new ArgumentException(DrinkConstants.InvalidDrinkType);
            }

            Type = type;
        }

    }
}
