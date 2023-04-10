using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(x => x.ParentCategory)
               .WithMany()
               .HasForeignKey(e => e.ParentCategoryId)
               .HasPrincipalKey(e => e!.Id);
        }
    }
}
