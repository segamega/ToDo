using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Domain.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(5000);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ProjectId).IsRequired();

            builder.HasOne(x => x.Project)
               .WithMany()
               .HasForeignKey(e => e.ProjectId)
               .HasPrincipalKey(e => e!.Id);
        }
    }
}
