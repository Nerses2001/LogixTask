using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.EntityConfiguration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CurseName).IsRequired().HasMaxLength(100);

            builder.HasMany(c => c.CourseApplicationUsers)
                .WithOne(uc => uc.Course)
                .HasForeignKey(uc => uc.CourseId);
        }
    }
}
