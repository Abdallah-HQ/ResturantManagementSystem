using ResturantManagementSystem.Domain;

namespace ResturantManagementSystem.Infrastructure.Data
{
    public class DrinkRepository
    {
        public static IEnumerable<Drink> LoadData()
        {
            return new List<Drink>
            {
                new Drink("Coffee", 4.50m, DrinkType.Hot),
                new Drink("Iced Tea", 3.75m, DrinkType.Cold),
                new Drink("Hot Chocolate", 5.00m, DrinkType.Hot),
                new Drink("Lemonade", 4.25m, DrinkType.Cold),
                new Drink("Herbal Tea", 3.90m, DrinkType.Hot),
                new Drink("Orange Juice", 4.10m, DrinkType.Hot),
                new Drink("Espresso", 3.60m, DrinkType.Cold),
                new Drink("Cola", 3.40m, DrinkType.Hot),
                new Drink("Matcha Latte", 5.25m, DrinkType.Hot),
                new Drink("Sparkling Water", 2.95m, DrinkType.Cold)
            };
        }
    }
}
