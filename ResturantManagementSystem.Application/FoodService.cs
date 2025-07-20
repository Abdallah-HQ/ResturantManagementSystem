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
        public void AddFood(CreateFoodDto foodDto)
        {
            if (foodDto is null)
                throw new ArgumentNullException(nameof(foodDto));
            if (FoodDtoValidation(foodDto))
            {
                foods.Add(new Food(foodDto.Name, foodDto.Price));
            }
        }

        public void Update(UpdatedFoodDto updatedFood)
        {
            var food = foods.FirstOrDefault(f => f.Id == updatedFood.Id && f.IsDeleted != true);
            if (food == null)
            {
                System.Console.WriteLine("this food dose not exist");
                return;
            }
            if (FoodDtoValidation(updatedFood))
            {
                food.SetName(updatedFood.Name);
                food.SetPrice(updatedFood.Price);
            }
           
        }

        public bool FoodDtoValidation(CreateFoodDto createfoodDto)
        {
            if (createfoodDto.Name is null || createfoodDto.Name.Length == 0)
                throw new ArgumentException("Name shouldn't be null or negative");

            if (createfoodDto.Price < 0)
                throw new ArgumentException("Price must be positive");
            return true;
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

        
    }
}
