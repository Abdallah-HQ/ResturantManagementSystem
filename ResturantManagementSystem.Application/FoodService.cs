using ResturantManagementSystem.Contract.DTOs;
using ResturantManagementSystem.Contract.Interfaces;
using ResturantManagementSystem.Domain;
using ResturantManagementSystem.Infrastructure.Data;

namespace ResturantManagementSystem.Application
{
    public class FoodService : IFoodService
    {
        public List<Food> foods;

        public FoodService()
        {
            foods = FoodRepository.LoadData().ToList();
        }
        public void AddFood(FoodDto foodDto)
        {
            foods.Add(new Food(foodDto.Name, foodDto.Price));
        }

        public void DeleteFood(int foodId)
        {
            var food = foods.FirstOrDefault(f => f.Id == foodId && f.IsDeleted != true);
            if (food == null)
            {
                Console.WriteLine("this food dose not exist");
                return;
            }
            food.Delete();

            
        }

        public IEnumerable<FoodDto> GetAll()
        {
            return foods
                .Where(f => f.IsDeleted != true)
                .Select(f => new FoodDto(f.Id, f.Name, f.Price));
        }

        public void PrintAllFoods()
        {
            foreach (var food in GetAll())
            {
                Console.WriteLine(food.ToString());
            }
        }

        public FoodDto GetById(int id)
        {
           var food = foods.FirstOrDefault(f => f.Id == id && f.IsDeleted != true);
            if(food == null)
                System.Console.WriteLine("this food dose not exist");
            return new FoodDto(food.Id, food.Name, food.Price);
        }

        public IEnumerable<FoodDto> GetByName(string name)
        {
            return foods
                .Where(f => f.IsDeleted != true && f.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Select(f => new FoodDto(f.Id, f.Name, f.Price));
        }

        public void UpdateName(int foodId, string newName)
        {
            var food = foods.FirstOrDefault(f => f.Id == foodId && f.IsDeleted != true);
            if (food == null)
            {
                System.Console.WriteLine("this food dose not exist");
                return;
            }
            food.SetName(newName);
        }

        public void UpdatePrice(int foodId, decimal newPrice)
        {
            var food = foods.FirstOrDefault(f => f.Id == foodId && f.IsDeleted != true);
            if (food == null)
            {
                System.Console.WriteLine("this food dose not exist");
                return;
            }
            food.SetPrice(newPrice);
        }
    }
}
