using ResturantManagementSystem.Domain.Entities;

namespace ResturantManagementSystem.Contract.DTOs
{
    public class DrinkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DrinkType Type { get; set; }

        public DrinkDto(int id, string name, decimal price, DrinkType type)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public override string ToString()
        {
            return $"[{Id}]\t Name: {Name}, Price: {Price}, Type: {Type}";
        }
    }
}
