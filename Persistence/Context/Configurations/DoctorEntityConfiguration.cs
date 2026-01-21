using HealthyApp.Domain.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthyApp.Persistence.Context.Configurations;

public class DoctorEntityConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        //Primary Key
        builder.HasKey(p=>p.DoctorId);

        builder.Property(p => p.DoctorId)
            .HasDefaultValueSql("NEWID()");

        builder.Property(d => d.DoctorFullName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(d => d.Locationn)
            .IsRequired()
            .HasMaxLength(100);

        // Foreign Key
        builder.HasMany(d=>d.Appointments)
            .WithOne(a=>a.Doctor)
            .HasForeignKey(a=>a.DoctorId);
    }
}
