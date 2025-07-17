using ResturantManagementSystem.Domain;
using System;


namespace ResturantManagementSystem.Infrastructure.Data
{
    public class FoodRepository
    {
        public static IEnumerable<Food> LoadData()
        {
            return new List<Food>
            {
                new Food("Burger", 10.99m),
                new Food("Salad", 7.50m),
                new Food("Pizza", 12.00m),
                new Food("Pasta", 11.25m),
                new Food("Steak", 18.90m),
                new Food("Fries", 4.99m),
                new Food("Soup", 6.50m),
                new Food("Sushi", 14.75m),
                new Food("Sandwich", 8.40m),
                new Food("Ice Cream", 5.25m)
            };
        }
    }
}
