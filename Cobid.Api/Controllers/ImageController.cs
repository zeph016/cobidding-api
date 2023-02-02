using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService) => _imageService = imageService;
        
        [HttpGet("all"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<UserValidationImage>>>> GetValidationImages()
        {
            var images = await _imageService.GetValidationImages();
            return Ok(images);
        }
        [HttpGet("all/user={userId}"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<UserValidationImage>>>> GetValidationIdsByUserId(int userId)
        {
            var images = await _imageService.GetValidationIdsByUserId(userId);
            return Ok(images);
        }

        [HttpPost("add"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<UserValidationImage>>>> AddValidationId(UserValidationImage images)
        {
            var result = await _imageService.AddValidationId(images);
            return Ok(result);
        }
        [HttpPost("add-list"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<UserValidationImage>>>> AddValidationIds(List<UserValidationImage> images)
        {
            var result = await _imageService.AddValidationIds(images);
            return Ok(result);
        }
        [HttpGet("count/user={userId}"), Authorize]
        public async Task<Int64> CountImagesByUserId(int userId)
        {
            var count = await _imageService.CountImagesByUserId(userId);
            return count;
        }
    }
}
