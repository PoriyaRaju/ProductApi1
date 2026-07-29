using first_dotnet_app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace first_dotnet_app.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
        public void Configure(EntityTypeBuilder<Product> builder)
        {
                // Table name
                builder.ToTable("products");

                // Primary Key
                builder.HasKey(p => p.Id);

                // Id Column
                builder.Property(p => p.Id)
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuidv7()")
                        .ValueGeneratedOnAdd();

                // Name
                builder.Property(p => p.Name)
                        .HasColumnName("name")
                        .HasMaxLength(100)
                        .IsRequired();

                // Descriptions
                builder.Property(p => p.Description)
                        .HasColumnName("descriptions")
                        .HasMaxLength(500);


                // Price

                builder.HasIndex(p => p.Price)
                        .HasDatabaseName("idx_products_price");


                builder.Property(p => p.Price)
                        .HasColumnName("price")
                        .HasPrecision(18, 2)
                        .IsRequired();

                // IsAvailabel
                builder.Property(p => p.IsAvailabel)
                        .HasColumnName("is_availabel")
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .IsRequired();

                // Created_at
                builder.Property(p => p.CreatedAt)
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()")
                        .ValueGeneratedOnAdd();

                // UpdatedAt
                builder.Property(p => p.UpdatedAt)
                        .HasColumnName("updated_at")
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()")
                        .ValueGeneratedOnAddOrUpdate();

        }

}
