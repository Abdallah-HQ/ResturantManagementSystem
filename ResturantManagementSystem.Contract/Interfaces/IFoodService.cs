using ResturantManagementSystem.Contract.DTOs;
using ResturantManagementSystem.Contract.Results;
using System;

namespace ResturantManagementSystem.Contract.Interfaces
{
    public interface IFoodService
    {
        FoodDto GetById(int id);
        
        IEnumerable<FoodDto> GetAll();
        
        OperationResult DeleteFood(int id);
        
        IEnumerable<FoodDto> GetByName(string name);
       
        OperationResult AddFood(CreateFoodDto foodDto);

        OperationResult Update(UpdatedFoodDto updatedfood);

    }
}
