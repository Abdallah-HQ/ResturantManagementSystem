using ResturantManagementSystem.Contract.DTOs;
using ResturantManagementSystem.Contract.Results;

namespace ResturantManagementSystem.Contract.Interfaces
{
    public interface IDrinkService
    {
        DrinkDto GetById(int id);

        IEnumerable<DrinkDto> GetAll();
        
        OperationResult DeleteDrink(int id);

        IEnumerable<DrinkDto> GetByName(string name); 

        OperationResult AddDrink(CreateDrinkDto drink);

        OperationResult Update(UpdatedDrinkDto updatedDrink);
    }
}
