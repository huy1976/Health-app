using HealthyApp.Domain.Appointments;
using HealthyApp.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HealthyApp.Resources.AppointmentResources;

namespace HealthyApp.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;
    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateAppointment([FromBody] AppointmentViewModel viewModel)
    {
        try
        {
            var result = await _appointmentService.AddAppointment(viewModel.DoctorId, viewModel.PatientId, viewModel.AppointmentDate, viewModel.Status, viewModel.Note);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAppointment([FromQuery] string appointmentId)
    {
        try
        {
            var result = await _appointmentService.RemoveAppointment(appointmentId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPatch]
    public async Task<IActionResult> UpdateAppointment([FromBody] UpdateAppointmentViewModel viewModel)
    {
        try
        {
            var result = await _appointmentService.UpdateAppointment(viewModel.AppointmentId, viewModel.DoctorId, viewModel.PatientId, viewModel.AppointmentDate, viewModel.Status, viewModel.Note);
            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    public async Task<GetAppointmentViewModel> GetFrofile([FromQuery] string appointmentId)
    {
        try
        {
            var reuslt = await _appointmentService.GetAppointmentProfile(appointmentId);
            return reuslt;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
} 

