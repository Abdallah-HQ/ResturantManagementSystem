using ResturantManagementSystem.Contract.DTOs;
using ResturantManagementSystem.Contract.Interfaces;
using ResturantManagementSystem.Contract.Results;
using ResturantManagementSystem.Domain;
using ResturantManagementSystem.Infrastructure.Data;
using System.Linq;

namespace ResturantManagementSystem.Application
{
    public class DrinkService : IDrinkService
    {
        List<Drink> drinks;
        public DrinkService()
        {
            drinks = DrinkRepository.LoadData().ToList();
        }

        public OperationResult AddDrink(CreateDrinkDto drink)
        {
            if (drink == null)
                return OperationResult.Fail("Drink data is null");

            if (DrinkDtoValidation(drink)) 
            {
                drinks.Add(new Drink(drink.Name, drink.Price, drink.Type));
                return OperationResult.SuccessResult(" Drink added successfully");
            }
            return OperationResult.Fail("Validation Faild");
        }

        public OperationResult DeleteDrink(int drinkId)
        {
            var drink = drinks.FirstOrDefault(d => d.Id == drinkId && d.IsDeleted != true);
            if (drink == null)
                return OperationResult.Fail("Drink not found"); 
            drink.Delete();
            return OperationResult.SuccessResult("Drink deleted successfully");
        }

        public OperationResult Update(UpdatedDrinkDto updatedDrink)
        {
            var drink = drinks.FirstOrDefault(d => d.Id == updatedDrink.Id && d.IsDeleted != true);
            if (drink == null)
                return OperationResult.Fail("Drink not found.");

            if (DrinkDtoValidation(updatedDrink))
            {
                drink.SetName(updatedDrink.Name);
                drink.SetPrice(updatedDrink.Price);
                drink.SetType(updatedDrink.Type);
                return OperationResult.SuccessResult("Drink Updated successfully");
            }
            return OperationResult.Fail("Validation Faild");

        }

        public bool DrinkDtoValidation(CreateDrinkDto createDrinkDto)
        {
            if (createDrinkDto.Name is null || createDrinkDto.Name.Length == 0)
                throw new ArgumentException("Name shouldn't be null or negative");

            if (createDrinkDto.Price < 0)
                throw new ArgumentException("Price must be positive");

            if (createDrinkDto.Type.ToString() != "Hot" && createDrinkDto.Type.ToString() != "Cold")
                throw new ArgumentException("Invalid type");
            return true;
        }

        public IEnumerable<DrinkDto> GetAll()
        {
            return drinks
                .Where(d => d.IsDeleted != true)
                .Select(d => new DrinkDto(d.Id, d.Name, d.Price, d.Type));
        }

        public DrinkDto GetById(int drinkId)
        {
            var drink = drinks.FirstOrDefault(d => d.Id == drinkId && d.IsDeleted != true);
            if (drink == null)
            {
                Console.WriteLine("this drink dose not exist");
                return null;
            }
            return new DrinkDto(drink.Id, drink.Name, drink.Price, drink.Type);
        }

        public IEnumerable<DrinkDto> GetByName(string name)
        {
            return drinks
                .Where(d => d.IsDeleted != true && d.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Select(d => new DrinkDto(d.Id, d.Name, d.Price, d.Type));
        }

        public void PrintAllDrinks()
        {
            foreach (var drink in GetAll())
            {
                Console.WriteLine(drink.ToString());
            }
        }
    }
}
