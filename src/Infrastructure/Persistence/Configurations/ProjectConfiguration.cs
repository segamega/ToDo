using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(x => x.Category)
               .WithMany()
               .HasForeignKey(e => e.CategoryId)
               .HasPrincipalKey(e => e!.Id);
        }
    }
}
