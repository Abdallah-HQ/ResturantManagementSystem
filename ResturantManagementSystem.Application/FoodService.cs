using ResturantManagementSystem.Contract.DTOs;
using ResturantManagementSystem.Contract.Interfaces;
using ResturantManagementSystem.Contract.Results;
using ResturantManagementSystem.Domain.Entities;
using ResturantManagementSystem.Domain.Shared.Constants;
using ResturantManagementSystem.Infrastructure.Persistence;

namespace ResturantManagementSystem.Application
{
    public class FoodService : IFoodService
    {
        private readonly AppDbContext _context;

        public FoodService()
        {
            _context = new AppDbContext();
        }
        
        public OperationResult AddFood(CreateFoodDto foodDto)
        {
            if (foodDto is null)
            {
                return OperationResult.Fail(FoodConstants.FoodDataIsNull);
            }
               
            if (FoodDtoValidation(foodDto))
            {
                _context.Foods.Add(new Food(foodDto.Name, foodDto.Price));
                _context.SaveChanges();
                return OperationResult.SuccessResult(FoodConstants.FoodAddedSuccessfully);
            }

            return OperationResult.Fail(FoodConstants.ValidationFaild);
        }

        public OperationResult Update(UpdatedFoodDto updatedFood)
        {
            var food = _context.Foods.FirstOrDefault(f => f.Id == updatedFood.Id && f.IsDeleted != true);
            
            if (food is null)
            {
                OperationResult.Fail(FoodConstants.FoodNotFound);
            }
                
            if (FoodDtoValidation(updatedFood))
            {
                food.SetName(updatedFood.Name);
                food.SetPrice(updatedFood.Price);
                _context.SaveChanges();
                return OperationResult.SuccessResult(FoodConstants.FoodUpdatedSuccessfully);
            }
                        
            return OperationResult.Fail(FoodConstants.ValidationFaild);
        }

        public bool FoodDtoValidation(CreateFoodDto createfoodDto)
        {
            if (createfoodDto.Name is null || createfoodDto.Name.Length == 0)
            {
                throw new ArgumentException(FoodConstants.FoodNameShouldntBeNullOrEmpty);
            }
              
            if (createfoodDto.Price < 0)
            {
                throw new ArgumentException(FoodConstants.FoodPriceMustBePositive);
            }
            
            return true;
        }

        public OperationResult DeleteFood(int foodId)
        {
            var food = _context.Foods.FirstOrDefault(f => f.Id == foodId && f.IsDeleted != true);
            if (food is null)
            {
                return OperationResult.Fail(FoodConstants.FoodNotFound);
            }
                
            food.Delete();
            _context.SaveChanges();
            return OperationResult.SuccessResult(FoodConstants.FoodDeletedSuccessfully);
        }

        public IEnumerable<FoodDto> GetAll()
        {
            return _context.Foods
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
            var food = _context.Foods.FirstOrDefault(f => f.Id == id && f.IsDeleted != true);
            
            if (food is null)
            {
                System.Console.WriteLine(FoodConstants.FoodNotFound);
            }
                
            return new FoodDto(food.Id, food.Name, food.Price);
        }

        public IEnumerable<FoodDto> GetByName(string name)
        {
            return _context.Foods
                .Where(f => f.IsDeleted != true && f.Name.ToLower().Contains(name.ToLower()))
                .Select(f => new FoodDto(f.Id, f.Name, f.Price));
        }
    }
}
