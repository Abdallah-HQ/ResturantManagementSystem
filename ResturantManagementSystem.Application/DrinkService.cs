using ResturantManagementSystem.Contract.DTOs;
using ResturantManagementSystem.Contract.Interfaces;
using ResturantManagementSystem.Contract.Results;
using ResturantManagementSystem.Domain.Entities;
using ResturantManagementSystem.Domain.Shared.Constants;
using ResturantManagementSystem.Infrastructure.Persistence;

namespace ResturantManagementSystem.Application
{
    public class DrinkService : IDrinkService
    {
        private readonly AppDbContext _context;
        public DrinkService()
        {
            _context = new AppDbContext();
        }

        public OperationResult AddDrink(CreateDrinkDto drink)
        {
            if (drink is null)
            {
                return OperationResult.Fail(DrinkConstants.DrinkDataIsNull);
            }

            if (DrinkDtoValidation(drink))
            {
                _context.Drinks.Add(new Drink(drink.Name, drink.Price, drink.Type));
                _context.SaveChanges();
                return OperationResult.SuccessResult(DrinkConstants.DrinkAddedSuccessfully);
            }
            return OperationResult.Fail(DrinkConstants.ValidationFaild);
        }

        public OperationResult DeleteDrink(int drinkId)
        {
            var drink = _context.Drinks.FirstOrDefault(d => d.Id == drinkId && d.IsDeleted != true);

            if (drink is null)
            {
                return OperationResult.Fail(DrinkConstants.DrinkNotFound);
            }

            drink.Delete();
            _context.SaveChanges();
            return OperationResult.SuccessResult(DrinkConstants.DrinkDeletedSuccessfully);
        }

        public OperationResult Update(UpdatedDrinkDto updatedDrink)
        {
            var drink = _context.Drinks.FirstOrDefault(d => d.Id == updatedDrink.Id && d.IsDeleted != true);

            if (drink is null)
            {
                return OperationResult.Fail(DrinkConstants.DrinkNotFound);
            }

            if (DrinkDtoValidation(updatedDrink))
            {
                drink.SetName(updatedDrink.Name);
                drink.SetPrice(updatedDrink.Price);
                drink.SetType(updatedDrink.Type);
                _context.SaveChanges();
                return OperationResult.SuccessResult(DrinkConstants.DrinkUpdatedSuccessfully);
            }

            return OperationResult.Fail(DrinkConstants.ValidationFaild);
        }

        public bool DrinkDtoValidation(CreateDrinkDto createDrinkDto)
        {
            if (createDrinkDto.Name is null || createDrinkDto.Name.Length == 0)
            {
                throw new ArgumentException(DrinkConstants.DrinkNameShouldntBeNullOrEmpty);
            }

            if (createDrinkDto.Price < 0)
            {
                throw new ArgumentException(DrinkConstants.DrinkPriceMustBePositive);
            }

            if (createDrinkDto.Type.ToString() != DrinkType.Hot.ToString() && createDrinkDto.Type.ToString() != DrinkType.Cold.ToString())
            {
                throw new ArgumentException(DrinkConstants.InvalidDrinkType);
            }

            return true;
        }

        public IEnumerable<DrinkDto> GetAll()
        {
            return _context.Drinks
                .Where(d => d.IsDeleted != true)
                .Select(d => new DrinkDto(d.Id, d.Name, d.Price, d.Type));
        }

        public DrinkDto GetById(int drinkId)
        {
            var drink = _context.Drinks.FirstOrDefault(d => d.Id == drinkId && d.IsDeleted != true);
            if (drink is null)
            {
                Console.WriteLine(DrinkConstants.DrinkNotFound);
                return null;
            }

            return new DrinkDto(drink.Id, drink.Name, drink.Price, drink.Type);
        }

        public IEnumerable<DrinkDto> GetByName(string name)
        {
            return _context.Drinks
                .Where(d => d.IsDeleted != true && d.Name.ToLower().Contains(name.ToLower()))
                .Select(d => new DrinkDto(d.Id, d.Name, d.Price, d.Type));
        }

        public void PrintAllDrinks()
        {
            foreach (var drink in GetAll())
            {
                Console.WriteLine(drink.ToString());
            }
        }
    }
}
