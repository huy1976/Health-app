using AutoMapper;
using HealthyApp.Domain.Patients;
using HealthyApp.Repositories.IRepositories;
using HealthyApp.Repositories1.IRepositories;
using HealthyApp.Resources.DoctorResources;
using HealthyApp.Resources.PatientResources;
using HealthyApp.Services.IServices;

namespace HealthyApp.Services;

public class PatientServices : IPatientServices
{
    private readonly IUnitOfWork1 _unitOfWork1;
    private readonly IPatientsRepository _patientsRepository;
    private readonly IMapper _mapper;

    public PatientServices(IPatientsRepository patientsRepository, IUnitOfWork1 unitOfWork1, IMapper mapper)
    {
        _patientsRepository = patientsRepository;
        _unitOfWork1 = unitOfWork1;
        _mapper = mapper;
    }

    public async Task<bool> ADDPatient(string patientName, string phoneNumber, string email)
    {
        var patientToAdd = new Patient(patientName, phoneNumber, email);
        if (patientToAdd != null)
        {
            _patientsRepository.AddPatient(patientToAdd);
        }
        else
        {
            throw new Exception("Dữ liệu ko hợp lệ để thêm vào");
        }
        return await _unitOfWork1.CompleteAsync();
    }

    public async Task<bool> RemovePatient(string patientId)
    {
        var patientToDelete = await _patientsRepository.GetPatientById(patientId);
        if (patientToDelete != null)
        {
            _patientsRepository.RemovePatient(patientToDelete);
        }
        else
        {
            throw new Exception("Không tồn tai Id bệnh nhân cần xóa");
        }
        return await _unitOfWork1.CompleteAsync();
    }
    public async Task<bool> UpdatePatient(string patientId, string? patientName, string? phoneNumber, string? email)
    {
        var patientToUpdate = await _patientsRepository.GetPatientById(patientId);
        if (patientToUpdate != null)
        {
            if (patientName != null) patientToUpdate.UpdatePatientName(patientName);
            if (phoneNumber != null) patientToUpdate.UpdatePhoneNumber(phoneNumber);
            if (email != null) patientToUpdate.UpdateEmail(email);

        }
        else
        {
            throw new Exception("Không tìm thấy bệnh nhân cần cập nhật");
        }
        return await _unitOfWork1.CompleteAsync();
    }
    public async Task<GetPatientProfileViewModel> GetPatientProfile(string patientId)
    {
        var patientToGet = await _patientsRepository.GetPatientById(patientId);
        if (patientToGet != null)
        {
            var patient = _mapper.Map<GetPatientProfileViewModel>(patientToGet);
            return patient ;
        }
        else
        {
            throw new Exception("Not Found");
        }
    }

   
}
