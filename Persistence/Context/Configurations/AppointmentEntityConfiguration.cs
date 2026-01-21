// Tạo bảng nhập các đối tượng để EF Core hiểu và xác định các khóa chính khóa ngoại ràng buộc và  hành vi khi xóa

using HealthyApp.Domain.Appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthyApp.Persistence.Context.Configurations;

public class AppointmentEntityConfiguration : IEntityTypeConfiguration<Appointment> // Tạo ra bảng thiết kế chi tiết cho bảng
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.AppointmentId); //

        // Nếu bạn dùng Guid thì có thể cấu hình ID tự sinh như sau:
        builder.Property(a => a.AppointmentId)
            .HasDefaultValueSql("NEWID()");
         
        // Cấu hình quan hệ với Patient (1 Patient - nhiều Appointmnet)
        builder.HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Cascade); // Xóa nhiều bệnh nhân sẽ xóa luôn lịch hẹn

        // Cấu hình quan hệ với Doctor (1 Doctor - nhiều Appointment)
        builder.HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId);  // Khi xóa Doctor set Doctor về null
       
        // Cấu hình các property khác nếu cần
        builder.Property(a => a.AppointmentDate)
            .IsRequired();  // Tức là ko dc NULL (nếu null sẽ báo lỗi)

        builder.Property(a => a.Status)
            .IsRequired()
            .HasMaxLength(50);
    }
}
