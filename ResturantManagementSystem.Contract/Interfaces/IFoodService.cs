using ResturantManagementSystem.Contract.DTOs;
using ResturantManagementSystem.Contract.Results;
using System;

namespace ResturantManagementSystem.Contract.Interfaces
{
    public interface IFoodService
    {
        // Read foods
        FoodDto GetById(int id);
        IEnumerable<FoodDto> GetByName(string name); // All foods that its name contain this name
        IEnumerable<FoodDto> GetAll();

        // Add new Food
        OperationResult AddFood(CreateFoodDto foodDto);

        // Delete existing food
        OperationResult DeleteFood(int id);

        // Update existing food
        OperationResult Update(UpdatedFoodDto updatedfood);

    }
}
