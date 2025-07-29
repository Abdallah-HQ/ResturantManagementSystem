using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResturantManagementSystem.Domain.Entities;

namespace ResturantManagementSystem.Infrastructure.Persistence.Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasData(LoadFoods());
        }

        private List<Food> LoadFoods()
        {
            return new List<Food>
            {
                 new Food("Burger", 10.99m)
                 {
                    Id = -11
                 },

                  new Food("Salad", 7.50m)
                 {
                    Id = -12
                 },

                   new Food("Pizza", 12.00m)
                 {
                    Id = -13
                 }
            };
        }
    }
}

