using ResturantManagementSystem.Domain;

namespace ResturantManagementSystem.Infrastructure.Data
{
    public class DrinkRepository
    {
        public static IEnumerable<Drink> LoadData()
        {
            return new List<Drink>
            {
                new Drink("Coffee", 4.50m, true),
                new Drink("Iced Tea", 3.75m, false),
                new Drink("Hot Chocolate", 5.00m, true),
                new Drink("Lemonade", 4.25m, false),
                new Drink("Herbal Tea", 3.90m, true),
                new Drink("Orange Juice", 4.10m, false),
                new Drink("Espresso", 3.60m, true),
                new Drink("Cola", 3.40m, false),
                new Drink("Matcha Latte", 5.25m, true),
                new Drink("Sparkling Water", 2.95m, false)
            };
        }
    }
}
