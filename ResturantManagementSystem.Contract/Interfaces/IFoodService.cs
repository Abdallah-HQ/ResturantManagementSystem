using ResturantManagementSystem.Contract.DTOs;
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
        void AddFood(FoodDto foodDto);

        // Delete existing food
        void DeleteFood(int id);

        // Update existing food
        void UpdateName(int foodId, string newName);
        void UpdatePrice(int foodId, decimal newPrice);

    }
}
