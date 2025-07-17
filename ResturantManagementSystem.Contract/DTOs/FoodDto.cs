using System;


namespace ResturantManagementSystem.Contract.DTOs
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public FoodDto(int id, string name, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"[{Id}]\t Name: {Name}, Price: {Price}";
        }
    }
}
