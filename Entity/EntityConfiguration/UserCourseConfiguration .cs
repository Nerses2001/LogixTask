using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.EntityConfiguration
{
    public class UserCourseConfiguration: IEntityTypeConfiguration<UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> builder)
        {
            builder.HasKey(uc => new { uc.UserEmail, uc.CourseId });
            builder.HasOne(uc => uc.ApplicationUser)
                .WithMany(u => u.UserCourses)
                .HasForeignKey(uc => uc.UserEmail);

            builder.HasOne(uc => uc.Course)
                .WithMany(c => c.CourseApplicationUsers)
                .HasForeignKey(uc => uc.CourseId);
        }
    }
}
