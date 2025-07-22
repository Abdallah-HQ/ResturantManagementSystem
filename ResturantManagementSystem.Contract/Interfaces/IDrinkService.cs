using ResturantManagementSystem.Contract.DTOs;
using ResturantManagementSystem.Contract.Results;

namespace ResturantManagementSystem.Contract.Interfaces
{
    public interface IDrinkService
    {
        // Read Drinks
        DrinkDto GetById(int id);
        IEnumerable<DrinkDto> GetByName(string name); // All foods that its name contain this name
        IEnumerable<DrinkDto> GetAll();

        // Add new Drink
        OperationResult AddDrink(CreateDrinkDto drink);//CreateDrinkDto

        //Delete existing drink
        OperationResult DeleteDrink(int id);

        // Update existing drink
        OperationResult Update(UpdatedDrinkDto updatedDrink);
        
    }
}
