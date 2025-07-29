using ResturantManagementSystem.Domain.Entities;

namespace ResturantManagementSystem.Contract.DTOs
{

    public class CreateDrinkDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DrinkType Type { get; set; }
    }
}
