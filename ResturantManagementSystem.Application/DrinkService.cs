using ResturantManagementSystem.Contract.DTOs;
using ResturantManagementSystem.Contract.Interfaces;
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

        public void DeleteDrink(int drinkId)
        {
            var drink = drinks.FirstOrDefault(d => d.Id == drinkId && d.IsDeleted != true);
            if (drink == null)
            {
                Console.WriteLine("this drink dose not exist");
                return;
            }
            drink.Delete();
        }

        public void UpdateName(int drinkId, string newName)
        {
            var drink = drinks.FirstOrDefault(d => d.Id == drinkId && d.IsDeleted != true);
            if (drink == null)
            {
                Console.WriteLine("this drink dose not exist");
                return;
            }
            drink.SetName(newName);
        }

        public void UpdatePrice(int drinkId, decimal newPrice)
        {
            var drink = drinks.FirstOrDefault(d => d.Id == drinkId && d.IsDeleted != true);
            if (drink == null)
            {
                Console.WriteLine("this drink dose not exist");
                return;
            }
            drink.SetPrice(newPrice);
        }

        public void UpdateTemperature(int drinkId, bool newTemperature)
        {
            var drink = drinks.FirstOrDefault(d => d.Id == drinkId && d.IsDeleted != true);
            if (drink == null)
            {
                Console.WriteLine("this drink dose not exist");
                return;
            }
            drink.SetIsHot(newTemperature);
        }

        public void AddDrink(DrinkDto drink)
        {
            drinks.Add(new Drink(drink.Name, drink.Price, drink.IsHot));
        }

        public IEnumerable<DrinkDto> GetAll()
        {
            return drinks
                .Where(d => d.IsDeleted != true)
                .Select(d => new DrinkDto(d.Id, d.Name, d.Price, d.IsHot));
        }

        public DrinkDto GetById(int drinkId)
        {
            var drink = drinks.FirstOrDefault(d => d.Id == drinkId && d.IsDeleted != true);
            if (drink == null)
            {
                Console.WriteLine("this drink dose not exist");
                return null;
            }
            return new DrinkDto(drink.Id, drink.Name, drink.Price, drink.IsHot);
        }

        public IEnumerable<DrinkDto> GetByName(string name)
        {
            return drinks
                .Where(d => d.IsDeleted != true && d.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Select(d => new DrinkDto(d.Id, d.Name, d.Price, d.IsHot));
        }
    }
}
