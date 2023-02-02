using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;
        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Gender>>>> GetGenders()
        {
            var genders = await _genderService.GetGendersAsync();
            return Ok(genders);
        }
        [HttpGet("{genderId}")]
        public async Task<ActionResult<ServiceResponse<Gender>>> GetGender(int genderId)
        {
            var gender = await _genderService.GetGenderAsync(genderId);
            return Ok(gender);
        }
    }
}
