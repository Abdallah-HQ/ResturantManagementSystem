using ResturantManagementSystem.Application;
using ResturantManagementSystem.Contract.DTOs;
using ResturantManagementSystem.Domain.Entities;
using ResturantManagementSystem.Domain.Shared.Constants;
using ResturantManagementSystem.Infrastructure.Persistence;

class Program
{
    static FoodService foodService = new FoodService();
    
    static DrinkService drinkService = new DrinkService();

    static void Main(string[] args)
    {
        PrintMenuList();
        while (true)
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    foodService.PrintAllFoods();
                    break;

                case "2":
                    drinkService.PrintAllDrinks();
                    break;
                
                case "3":
                    AddNewFood();
                    break;

                case "4":
                    AddNewDrink();
                    break;

                case "5":
                    DeleteFoodById();
                    break;

                case "6":
                    DeleteDrinkById();
                    break;

                case "7":
                    UpdateFood();
                    break;

                case "8":
                    UpdateDrink();
                    break;

                case "9":
                    SearchFoodByName();
                    break;

                case "10":
                    SearchDrinkByName();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine(ProgramConstants.InvalidInput);
                    break;
            }
        }
    }

    private static void AddNewFood()
    {
        Console.Write(ProgramConstants.EnterName);
        
        string foodName = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(foodName))
        {
            Console.WriteLine(ProgramConstants.InvalidName);
            return;
        }

        Console.Write(ProgramConstants.EnterPrice);
        
        if (!decimal.TryParse(Console.ReadLine(), out decimal foodPrice) || foodPrice < 0)
        {
            Console.WriteLine(ProgramConstants.InvalidPrice);
            return;
        }

        var result = foodService.AddFood(new CreateFoodDto
        {
            Name = foodName,
            Price = foodPrice
        });
        
        Console.WriteLine(result.Message);
    }

    private static void AddNewDrink()
    {
        Console.Write(ProgramConstants.EnterName);
        
        string drinkName = Console.ReadLine();
       
        if (string.IsNullOrWhiteSpace(drinkName))
        {
            Console.WriteLine(ProgramConstants.InvalidName);
            return;
        }

        Console.Write(ProgramConstants.EnterPrice);
        
        if (!decimal.TryParse(Console.ReadLine(), out decimal drinkPrice) || drinkPrice < 0)
        {
            Console.WriteLine(ProgramConstants.InvalidPrice);
            return;
        }

        Console.Write(ProgramConstants.EnterDrinkType);
        
        string drinkType = Console.ReadLine();
        
        if (!Enum.TryParse<DrinkType>(drinkType, true, out DrinkType type))
        {
            Console.WriteLine(ProgramConstants.InvalidDrinkType);
            return;
        }

        var result = drinkService.AddDrink(new CreateDrinkDto
        {
            Name = drinkName,
            Price = drinkPrice,
            Type = type
        });
        
        Console.WriteLine(result.Message);
    }

    static void DeleteFoodById()
    {
        Console.Write(ProgramConstants.EnterID);
        
        if (!int.TryParse(Console.ReadLine(), out int foodId))
        {
            Console.WriteLine(ProgramConstants.InvalidId);
            return;
        }

        var result = foodService.DeleteFood(foodId);
        
        Console.WriteLine(result.Message);
    }

    static void DeleteDrinkById()
    {
        Console.Write(ProgramConstants.EnterID);
       
        if (!int.TryParse(Console.ReadLine(), out int drinkId))
        {
            Console.WriteLine(ProgramConstants.InvalidId);
            return;
        }

        var result = drinkService.DeleteDrink(drinkId);
       
        Console.WriteLine(result.Message);
    }

    private static void UpdateFood()
    {
        Console.Write(ProgramConstants.EnterID);
        
        if (!int.TryParse(Console.ReadLine(), out int foodIdToUpdate))
        {
            Console.WriteLine(ProgramConstants.InvalidId);
            return;
        }

        FoodDto oldFood = foodService.GetById(foodIdToUpdate);

        if (oldFood  == null)
        {
            Console.WriteLine(ProgramConstants.ItemNotFound);
            return;
        }

        Console.Write(ProgramConstants.EnterNewName);
       
        string newFoodName = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(newFoodName))
        {
            newFoodName = oldFood.Name;
        }

        Console.Write(ProgramConstants.EnterNewPrice);
        
        string newPriceString = Console.ReadLine();
        
        if (!decimal.TryParse(newPriceString, out decimal newPrice) || string.IsNullOrEmpty(newPriceString))
        {
            newPrice = oldFood.Price;
        }
            
        var result = foodService.Update(new UpdatedFoodDto
        {
            Id = foodIdToUpdate,
            Name = newFoodName,
            Price = newPrice
        });
        
        Console.WriteLine(result.Message);
    }

    static void UpdateDrink()
    {
        Console.Write(ProgramConstants.EnterID);
        
        if (!int.TryParse(Console.ReadLine(), out int drinkId))
        {
            Console.WriteLine(ProgramConstants.InvalidId);
            return;
        }

        var oldDrink = drinkService.GetById(drinkId);
        
        if (oldDrink == null)
        {
            Console.WriteLine(ProgramConstants.ItemNotFound);
            return;
        }

        Console.Write(ProgramConstants.EnterNewName);
        
        string newName = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(newName))
        {
            newName = oldDrink.Name;
        }
            
        Console.Write(ProgramConstants.EnterNewPrice);
        
        string newPriceStr = Console.ReadLine();
        
        decimal newPrice;
       
        if (!decimal.TryParse(newPriceStr, out newPrice) || string.IsNullOrWhiteSpace(newPriceStr))
        {
            newPrice = oldDrink.Price;
        }

        Console.Write(ProgramConstants.EnterDrinkType);
        
        string newTypeStr = Console.ReadLine();
       
        DrinkType newType;
        
        if (string.IsNullOrWhiteSpace(newTypeStr))
        {
            newType = oldDrink.Type;
        }
            
        else if (!Enum.TryParse<DrinkType>(newTypeStr, true, out newType))
        {
            Console.WriteLine(ProgramConstants.InvalidDrinkType);
            return;
        }

        var result = drinkService.Update(new UpdatedDrinkDto
        {
            Id = drinkId,
            Name = newName,
            Price = newPrice,
            Type = newType
        });

        Console.WriteLine(result.Message);
    }

    static void SearchFoodByName()
    {
        Console.Write(ProgramConstants.EnterName);
        
        string name = Console.ReadLine();

        foreach (var food in foodService.GetByName(name))
        {
            Console.WriteLine(food);
        }
    }

    static void SearchDrinkByName()
    {
        Console.Write(ProgramConstants.EnterName);
        
        string name = Console.ReadLine();

        foreach (var drink in drinkService.GetByName(name))
        {
            Console.WriteLine(drink);
        }
    }

    public static void PrintMenuList()
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
    }
}
