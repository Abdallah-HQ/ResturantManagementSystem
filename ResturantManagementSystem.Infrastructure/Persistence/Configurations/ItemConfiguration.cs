using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResturantManagementSystem.Domain.Entities;

namespace ResturantManagementSystem.Infrastructure.Persistence.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasDiscriminator<string>("ItemType")
                .HasValue<Drink>("Drink")
                .HasValue<Food>("Food");

        }
    }
}

