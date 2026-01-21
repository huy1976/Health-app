using HealthyApp.Resources.DoctorResources;
using HealthyApp.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase // Này là kế thừa của ASPNetCore
    {
        private readonly IDoctorServices _doctorService;
        public DoctorsController(IDoctorServices doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorViewModel viewModel)
        {
            try
            {
                var result = await _doctorService.AddDt(viewModel.DoctorFullName, viewModel.PhoneNumber, viewModel.HospitalName, viewModel.Locationn);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }


        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor([FromQuery] string doctorId)
        {
            try
            {
                var result = await _doctorService.RemoveDoctor(doctorId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateDoctor( [FromBody] UpdateDoctorViewModel viewModel)
        {
            try
            {
                var result = await _doctorService.UpdateDoctor(viewModel.DoctorId,viewModel.DoctorFullName, viewModel.PhoneNumber, viewModel.HospitalName, viewModel.Locationn);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<GetDoctorProfileViewModel> GetDoctorProfile([FromQuery] string doctorId)
        {
            try
            {
                var result = await _doctorService.GetDoctorProfile(doctorId);
                return result;
            }
            catch
            {
                throw new Exception("Not Found");
            }
      
        }
    }
}
