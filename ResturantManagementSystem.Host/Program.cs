using ResturantManagementSystem.Application;
using ResturantManagementSystem.Contract.DTOs;
using ResturantManagementSystem.Domain;

class Program
{
    static FoodService foodService = new FoodService();
    static DrinkService drinkService = new DrinkService();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Restaurant Management System ---");
            Console.WriteLine("1. List all foods");
            Console.WriteLine("2. List all drinks");
            Console.WriteLine("3. Add new food");
            Console.WriteLine("4. Add new drink");
            Console.WriteLine("5. Delete food by ID");
            Console.WriteLine("6. Delete drink by ID");
            Console.WriteLine("7. Update food name");
            Console.WriteLine("8. Update drink name");
            Console.WriteLine("9. Get food by name");
            Console.WriteLine("10. Get drink by name");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    foodService.PrintAllFoods();
                    break;

                case "2":
                    foreach (var drink in drinkService.GetAll())
                        Console.WriteLine(drink);
                    break;

                case "3":
                    Console.Write("Food name: ");
                    string foodName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(foodName))
                    {
                        Console.WriteLine(Constants.Invalid + " name.");
                        break;
                    }

                    Console.Write("Food price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal foodPrice) || foodPrice < 0)
                    {
                        Console.WriteLine(Constants.Invalid + " price.");
                        break;
                    }

                    foodService.AddFood(new CreateFoodDto {
                        Name = foodName,
                        Price = foodPrice
                    });
                    Console.WriteLine("Food added successfully.");
                    break;

                case "4":
                    Console.Write("Drink name: ");
                    string drinkName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(drinkName))
                    {
                        Console.WriteLine(Constants.Invalid + " name.");
                        break;
                    }

                    Console.Write("Drink price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal drinkPrice) || drinkPrice < 0)
                    {
                        Console.WriteLine(Constants.Invalid + " price.");
                        break;
                    }

                    Console.Write("Food Type (Hot/Cold): ");
                    string drinkType = Console.ReadLine();
                    if (Enum.TryParse(drinkType, out DrinkType type))
                    {
                        Console.WriteLine(Constants.Invalid + " temperature format.");
                        break;
                    }

                    drinkService.AddDrink(new CreateDrinkDto
                    {
                        Name = drinkName,
                        Price = drinkPrice,
                        Type = type
                    });
                    Console.WriteLine("Drink added successfully.");
                    break;

                case "5":
                    Console.Write("Food ID to delete: ");
                    if (!int.TryParse(Console.ReadLine(), out int foodIdToDelete))
                    {
                        Console.WriteLine(Constants.Invalid + " ID.");
                        break;
                    }

                    foodService.DeleteFood(foodIdToDelete);
                    break;

                case "6":
                    Console.Write("Drink ID to delete: ");
                    if (!int.TryParse(Console.ReadLine(), out int drinkIdToDelete))
                    {
                        Console.WriteLine(Constants.Invalid + " ID.");
                        break;
                    }

                    drinkService.DeleteDrink(drinkIdToDelete);
                    break;

                case "7":
                    Console.Write("Food ID to update : ");
                    if (!int.TryParse(Console.ReadLine(), out int foodIdToUpdate))
                    {
                        Console.WriteLine(Constants.Invalid + " ID.");
                        break;
                    }

                    FoodDto oldFood = foodService.GetById(foodIdToUpdate);

                    Console.Write("New name (dont write any thing if you dont want update): ");
                    string newFoodName = null;
                    newFoodName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newFoodName))
                        newFoodName = oldFood.Name;

                    Console.Write("Enter new Price(dont write any thing if you dont want update): ");
                    string newPriceString = Console.ReadLine();
                    decimal newPrice;
                    if (!decimal.TryParse(newPriceString, out newPrice) || string.IsNullOrEmpty(newPriceString))
                       newPrice = oldFood.Price;

                    foodService.Update(new UpdatedFoodDto
                    {
                        Name = newFoodName,
                        Price = newPrice
                    });
                    break;

                case "8":
                    Console.Write("Drink ID to update name(dont write any thing if you dont want update): ");
                    if (!int.TryParse(Console.ReadLine(), out int drinkIdToUpdateName))
                    {
                        Console.WriteLine(Constants.Invalid + " ID.");
                        break;
                    }

                    DrinkDto oldDrink = drinkService.GetById(drinkIdToUpdateName);

                    Console.Write("New name(dont write any thing if you dont want update): ");
                    string newDrinkName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newDrinkName))
                    {
                        newDrinkName = oldDrink.Name;
                    }

                    Console.Write("Enter new Price(dont write any thing if you dont want update): ");
                    string newDrinkPriceString = Console.ReadLine();
                    decimal newDrinkPrice;
                    if (!decimal.TryParse(newDrinkPriceString, out newDrinkPrice) || string.IsNullOrEmpty(newDrinkPriceString))
                        newPrice = oldDrink.Price;
                    else
                        newPrice = newDrinkPrice;

                    Console.Write("Enter new Type(dont write any thing if you dont want update): ");
                    string newDrinkTypeString = Console.ReadLine();
                    DrinkType newDrinkType;
                    if (string.IsNullOrWhiteSpace(newDrinkTypeString))
                        newDrinkType = oldDrink.Type;
                    else
                        newDrinkType = (DrinkType)Enum.Parse(typeof(DrinkType), newDrinkTypeString);

                        drinkService.Update(new UpdatedDrinkDto
                        {
                            Name = newDrinkName,
                            Price = newDrinkPrice,
                            Type = newDrinkType
                        });
                    break;

                case "9":
                    Console.Write("Search food by name: ");
                    string foodSearchName = Console.ReadLine();
                    foreach (var food in foodService.GetByName(foodSearchName))
                        Console.WriteLine(food);
                    break;

                case "10":
                    Console.Write("Search drink by name: ");
                    string drinkSearchName = Console.ReadLine();
                    foreach (var drink in drinkService.GetByName(drinkSearchName))
                        Console.WriteLine(drink);
                    break;

                case "0":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine(Constants.Invalid);
                    break;
            }
        }
    }
}
public static class Constants
{
    public const string Invalid = "Invalid";
}
