using AutoMapper;
using HealthyApp.Domain.Appointments;
using HealthyApp.Domain.Doctors;
using HealthyApp.Domain.Patients;
using HealthyApp.Resources.AppointmentResources;
using HealthyApp.Resources.DoctorResources;
using HealthyApp.Resources.PatientResources;
using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Mapping;

public class ModelToViewModel : Profile
{
    public ModelToViewModel()
    {
        CreateMap<Doctor, GetDoctorProfileViewModel>()
            .ForMember(d =>d.DoctorFullName1,g =>g.MapFrom(a=>"Hello" +" "+a.DoctorFullName ));

        // Cú pháp của lệnh Formember 
        //    CreateMap<SourceClass, DestinationClass>()
        //.ForMember(dest => dest.TenThuocTinh,
        //           opt => opt.MapFrom(src => src.ThuocTinhKhac));
        CreateMap<Patient, GetPatientProfileViewModel>()
           .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments))
           .ForMember(dest => dest.AppointmentCount, opt => opt.MapFrom(src => src.Appointments.Count()));
        CreateMap<Patient, Patientprofile>();
        CreateMap<Appointment, GetAppointmentViewModel>();
            


    }
}
