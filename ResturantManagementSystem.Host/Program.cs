using ResturantManagementSystem.Application;
using ResturantManagementSystem.Contract.DTOs;

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
            Console.WriteLine("9. Update food price");
            Console.WriteLine("10. Update drink price");
            Console.WriteLine("11. Update drink temperature");
            Console.WriteLine("12. Get food by name");
            Console.WriteLine("13. Get drink by name");
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
                        Console.WriteLine("Invalid name.");
                        break;
                    }

                    Console.Write("Food price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal foodPrice) || foodPrice < 0)
                    {
                        Console.WriteLine("Invalid price.");
                        break;
                    }

                    foodService.AddFood(new FoodDto(0, foodName, foodPrice));
                    Console.WriteLine("Food added successfully.");
                    break;

                case "4":
                    Console.Write("Drink name: ");
                    string drinkName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(drinkName))
                    {
                        Console.WriteLine("Invalid name.");
                        break;
                    }

                    Console.Write("Drink price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal drinkPrice) || drinkPrice < 0)
                    {
                        Console.WriteLine("Invalid price.");
                        break;
                    }

                    Console.Write("Is hot (true/false): ");
                    string tempInput = Console.ReadLine();
                    if (!bool.TryParse(tempInput, out bool isHot))
                    {
                        Console.WriteLine("Invalid temperature format.");
                        break;
                    }

                    drinkService.AddDrink(new DrinkDto(0, drinkName, drinkPrice, isHot));
                    Console.WriteLine("Drink added successfully.");
                    break;

                case "5":
                    Console.Write("Food ID to delete: ");
                    if (!int.TryParse(Console.ReadLine(), out int foodIdToDelete))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    foodService.DeleteFood(foodIdToDelete);
                    break;

                case "6":
                    Console.Write("Drink ID to delete: ");
                    if (!int.TryParse(Console.ReadLine(), out int drinkIdToDelete))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    drinkService.DeleteDrink(drinkIdToDelete);
                    break;

                case "7":
                    Console.Write("Food ID to update name: ");
                    if (!int.TryParse(Console.ReadLine(), out int foodIdToUpdateName))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    Console.Write("New name: ");
                    string newFoodName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newFoodName))
                    {
                        Console.WriteLine("Invalid name.");
                        break;
                    }

                    foodService.UpdateName(foodIdToUpdateName, newFoodName);
                    break;

                case "8":
                    Console.Write("Drink ID to update name: ");
                    if (!int.TryParse(Console.ReadLine(), out int drinkIdToUpdateName))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    Console.Write("New name: ");
                    string newDrinkName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newDrinkName))
                    {
                        Console.WriteLine("Invalid name.");
                        break;
                    }

                    drinkService.UpdateName(drinkIdToUpdateName, newDrinkName);
                    break;

                case "9":
                    Console.Write("Food ID to update price: ");
                    if (!int.TryParse(Console.ReadLine(), out int foodIdToUpdatePrice))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    Console.Write("New price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal newFoodPrice) || newFoodPrice < 0)
                    {
                        Console.WriteLine("Invalid price.");
                        break;
                    }

                    foodService.UpdatePrice(foodIdToUpdatePrice, newFoodPrice);
                    break;

                case "10":
                    Console.Write("Drink ID to update price: ");
                    if (!int.TryParse(Console.ReadLine(), out int drinkIdToUpdatePrice))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    Console.Write("New price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal newDrinkPrice) || newDrinkPrice < 0)
                    {
                        Console.WriteLine("Invalid price.");
                        break;
                    }

                    drinkService.UpdatePrice(drinkIdToUpdatePrice, newDrinkPrice);
                    break;

                case "11":
                    Console.Write("Drink ID to update temperature: ");
                    if (!int.TryParse(Console.ReadLine(), out int drinkIdTemp))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    Console.Write("Is hot (true/false): ");
                    string tempStatusInput = Console.ReadLine();
                    if (!bool.TryParse(tempStatusInput, out bool tempStatus))
                    {
                        Console.WriteLine("Invalid format.");
                        break;
                    }

                    drinkService.UpdateTemperature(drinkIdTemp, tempStatus);
                    break;

                case "12":
                    Console.Write("Search food by name: ");
                    string foodSearchName = Console.ReadLine();
                    foreach (var food in foodService.GetByName(foodSearchName))
                        Console.WriteLine(food);
                    break;

                case "13":
                    Console.Write("Search drink by name: ");
                    string drinkSearchName = Console.ReadLine();
                    foreach (var drink in drinkService.GetByName(drinkSearchName))
                        Console.WriteLine(drink);
                    break;

                case "0":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
