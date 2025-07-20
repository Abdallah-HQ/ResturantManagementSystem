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
        void AddDrink(CreateDrinkDto drink);//CreateDrinkDto

        //Delete existing drink
        void DeleteDrink(int id);

        // Update existing drink
        void Update(UpdatedDrinkDto updatedDrink);
        
    }
}
