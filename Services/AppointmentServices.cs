using AutoMapper;
using HealthyApp.Domain.Appointments;
using HealthyApp.Repositories.IRepositories;
using HealthyApp.Repositories_of_Appointment.IRepositories;
using HealthyApp.Repositories1.IRepositories;
using HealthyApp.Resources.AppointmentResources;
using HealthyApp.Services.IServices;
using System.Net.WebSockets;

namespace HealthyApp.Services;

public class AppointmentServices : IAppointmentService
{
    readonly IAppointmentRepositories _appointmentsRepository;
    readonly IUnitofWorkAppointment _unit;
    readonly IMapper _mapper;
    readonly IPatientsRepository _patientsRepository;
    readonly IDoctorRepository _doctorRepository;

    public AppointmentServices(IAppointmentRepositories appointmentsRepository, IUnitofWorkAppointment unit, IMapper mapper, IPatientsRepository patientsRepository, IDoctorRepository doctorRepository)
    {
        _appointmentsRepository = appointmentsRepository;
        _unit = unit;
        _mapper = mapper;
        _patientsRepository = patientsRepository;
        _doctorRepository = doctorRepository;
    }

    public async Task<bool> AddAppointment( string doctorId, string patientId, DateTime appointmentDate, Estatus status, string note)
    {
        if (doctorId != null) {
            var doctor = await _doctorRepository.GetDoctorById(doctorId) ?? throw new Exception("ko có Id của bác sĩ này");
        }
        if (patientId != null) {
            var patient = await _patientsRepository.GetPatientById(patientId) ?? throw new Exception("Ko co Id cua benh nhan nay");
        }
        var appointmentToAdd = new Appointment(doctorId, patientId, appointmentDate, status, note);

        if (appointmentToAdd != null)
        {
            _appointmentsRepository.AddAppointment(appointmentToAdd);
        }
        else
        {
            throw new Exception("Dữ liệu ko hợp lệ để thêm vào cuộc hẹn");
        }
        return await _unit.CompleteAsync();
    }

    public async Task<GetAppointmentViewModel> GetAppointmentProfile(string appointmentId)
    {
        var appointmentToGet = await _appointmentsRepository.GetAppointmentById(appointmentId);
        if (appointmentToGet != null)
        {
            var appointment = _mapper.Map<GetAppointmentViewModel>(appointmentToGet);
            return appointment;
        }
        else
        {
            throw new Exception(" cuộc gặp đó ko tồn tại");
        }
    }

    public async Task<bool> RemoveAppointment(string appointmentId)
    {
       var appointmentToDelete= await _appointmentsRepository.GetAppointmentById(appointmentId);
        if(appointmentToDelete != null)
        {
            _appointmentsRepository.RemoveAppointment(appointmentToDelete);
        }
        else
        {
            throw new Exception("Không tồn tai cuộc họp cần xóa cần xóa");
        }
        return await _unit.CompleteAsync();
    }

    public async Task<bool> UpdateAppointment(string appointmentId, string? doctorId, string? patientId, DateTime dateTime, Estatus status, string note)
    {
        if (doctorId != null)
        {
            var doctor = await _doctorRepository.GetDoctorById(doctorId) ?? throw new Exception("ko có Id của bác sĩ này");
        }
        if (patientId != null)
        {
            var patient = await _patientsRepository.GetPatientById(patientId) ?? throw new Exception("Ko co Id cua benh nhan nay");
        }
        var appointmentToUpdate = await _appointmentsRepository.GetAppointmentById(appointmentId);
       
        if (appointmentToUpdate != null)
        {

            if (doctorId != null ) appointmentToUpdate.UpdateDoctorId(doctorId);
            if (patientId != null) appointmentToUpdate.UpdatePatientId(patientId);
            if (dateTime != null) appointmentToUpdate.UpdateAppointmentDate(dateTime);
            if (status != null) appointmentToUpdate.UpdatetStatus(status);
            if (note != null)  appointmentToUpdate.UpdateNote(note);
        }
        else
        {
            throw new Exception(" Không tìm thấy thông tin cuộc họp để cập nhật");
        }
        return await _unit.CompleteAsync() ;
    }
}
