using HealthyApp.Resources.DoctorResources;
using HealthyApp.Resources.PatientResources;
using HealthyApp.Services;
using HealthyApp.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthyApp.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IPatientServices _patientServices;
    public PatientsController(IPatientServices patientServices)
    { 
        _patientServices = patientServices;
    }
    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] PatientViewModel viewModel)
    {
        try
        {
            var result = await _patientServices.ADDPatient(viewModel.PatientName, viewModel.PhoneNumber, viewModel.Email);
            return Ok(result);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> DeletePatient([FromQuery] string patientId)
    {
        try
        {
            var result = await _patientServices.RemovePatient(patientId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPatch]
    public async Task<IActionResult> UpdatePatient([FromBody] UpdatePatientViewModel viewModel)
    {
        try
        {
            var result = await _patientServices.UpdatePatient(viewModel.PatientId, viewModel.PatientName, viewModel.PhoneNumber, viewModel.Email);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    public async Task<GetPatientProfileViewModel> GetPatientProfile([FromQuery] string patientId)
    {
        try
        {
            var result = await _patientServices.GetPatientProfile(patientId);
            return result;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
