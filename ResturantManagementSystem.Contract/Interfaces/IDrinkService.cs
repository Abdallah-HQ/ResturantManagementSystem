using ResturantManagementSystem.Contract.DTOs;

namespace ResturantManagementSystem.Contract.Interfaces
{
    public interface IDrinkService
    {
        // Read Drinks
        DrinkDto GetById(int id);
        IEnumerable<DrinkDto> GetByName(string name); // All foods that its name contain this name
        IEnumerable<DrinkDto> GetAll();

        // Add new Drink
        void AddDrink(DrinkDto drink);

        //Delete existing drink
        void DeleteDrink(int id);

        // Update existing drink
        void UpdateName(int drinkId, string newName);
        void UpdatePrice(int drinkId, decimal newPrice);
        void UpdateTemperature(int drinkId, bool newTemperature);
    }
}
