using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResturantManagementSystem.Domain.Entities;

namespace ResturantManagementSystem.Infrastructure.Persistence.Configurations
{
    public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.Property(x => x.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (DrinkType)Enum.Parse(typeof(DrinkType), v)
                );
            builder.HasData(LoadDrinks());
        }

        private List<Drink> LoadDrinks()
        {
            return new List<Drink>
            {
                new Drink("Coffee", 4.50m, DrinkType.Hot)
                {
                    Id = -1,
                    
                },
                
                new Drink("Hot Chocolate", 5.00m, DrinkType.Hot)
                {
                    Id = -2

                },
                
                new Drink("Iced Tea", 3.75m, DrinkType.Cold)
                {
                   Id = -3
                }
            };
        }
    }
}

