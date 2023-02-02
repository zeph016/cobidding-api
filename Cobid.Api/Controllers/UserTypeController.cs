using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;
        public UserTypeController(IUserTypeService userTypeService) => _userTypeService = userTypeService;

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<UserType>>>> GetUserTypesAsync()
        {
            var userTypes = await _userTypeService.GetUserTypesAsync();
            return Ok(userTypes);
        }
        [HttpGet("{userTypeId}")]
        public async Task<ActionResult<ServiceResponse<UserType>>> GetUserTypeAsync(int userTypeId)
        {
            var userType = await _userTypeService.GetUserTypeAsync(userTypeId);
            return Ok(userType);
        }
    }
}
