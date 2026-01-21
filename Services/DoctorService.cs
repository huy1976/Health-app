using AutoMapper;
using HealthyApp.Domain.Doctors;
using HealthyApp.Repositories.IRepositories;
using HealthyApp.Resources.DoctorResources;
using HealthyApp.Services.IServices;

namespace HealthyApp.Services;

public class DoctorService : IDoctorServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDoctorRepository _docRepository;
    private readonly IMapper _mapper;

    public DoctorService(IUnitOfWork unitOfWork, IDoctorRepository docRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _docRepository = docRepository;
        _mapper = mapper;
    }
    public async Task<bool> AddDt(string doctorName, string phoneNumber, string hospitalName, string location)
    {
        var doctorToAdd = new Doctor(doctorName, phoneNumber, hospitalName, location);
        if (doctorToAdd != null)
        {
            _docRepository.AddDoctor(doctorToAdd);
        }
        else
        {
            throw new Exception("Dữ liệu ko hợp lệ để thêm vào");
        }
        return await _unitOfWork.CompleteAsync();  // nếu không có dòng này thì nó không add xuống SQL
        // add-migration, update-database
    }
    public async Task<GetDoctorProfileViewModel> GetDoctorProfile(string doctorId)
    {
        var doctorToGet = await _docRepository.GetDoctorById(doctorId);
        if (doctorToGet != null)
        {
            var doctor = _mapper.Map<GetDoctorProfileViewModel>(doctorToGet);
            return doctor;
        }
        else
        {
            throw new Exception("Not Found");
        }

    }
    public async Task<bool> RemoveDoctor(string doctorId)
    {
        var doctorToDelete = await _docRepository.GetDoctorById(doctorId);
        if (doctorToDelete != null)
        {
            _docRepository.RemoveDoctor(doctorToDelete);
        }
        else
        {
            throw new Exception("Không tồn tai Id bác sĩ cần xóa");
        }
        return await _unitOfWork.CompleteAsync();
    }
    public async Task<bool> UpdateDoctor(string doctorId, string? doctorName, string? phoneNumber, string? hospitalName, string? location)
    {
        var doctorToUpdate = await _docRepository.GetDoctorById(doctorId);
        if (doctorToUpdate != null)
        {
            if (doctorName != null) doctorToUpdate.UpdateDoctorName(doctorName);
            if (phoneNumber != null) doctorToUpdate.UpdatePhoneNumber(phoneNumber);
            if (hospitalName != null) doctorToUpdate.UpdateHospitalname(hospitalName);
            if (location != null) doctorToUpdate.UpdateLocation(location);

        }
        else
        {
            throw new Exception("Không tìm thấy bác sĩ cần gặp");
        }
        return await _unitOfWork.CompleteAsync();
    }
}
