using System;


namespace ResturantManagementSystem.Contract.DTOs
{
    public class DrinkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsHot { get; set; }

        public DrinkDto(int id, string name, decimal price, bool isHot)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.IsHot = isHot;
        }

        public override string ToString()
        {
            return $"[{Id}]\t Name: {Name}, Price: {Price}, Type: {(IsHot ? "Hot Drink" : "Cold Drink")}";
        }
    }
}
