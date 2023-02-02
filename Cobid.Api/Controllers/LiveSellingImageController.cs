using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveSellingImageController : ControllerBase
    {
        private readonly ILiveSellingImageService _liveSellingImageService;
        public LiveSellingImageController(ILiveSellingImageService liveSellingImageService) => _liveSellingImageService = liveSellingImageService;

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<LiveSellingImage>>>> GetLiveSellingImagesAsync()
        {
            var lsImages = await _liveSellingImageService.GetLiveSellingImages();
            return Ok(lsImages);
        }

        [HttpGet("image/{lsImageId}")]
        public async Task<ActionResult<ServiceResponse<LiveSellingImage>>> GetLiveSellingImage(long lsImageId)
        {
            var lsImage = await _liveSellingImageService.GetLiveSellingImage(lsImageId);
            return Ok(lsImage);
        }

        [HttpGet("rel/{lsImageLSId}")]
        public async Task<ActionResult<ServiceResponse<LiveSellingImage>>> GetLSImagesByLSId(long lsImageLSId)
        {
            var lsImage = await _liveSellingImageService.GetLSImagesByLSId(lsImageLSId);
            return Ok(lsImage);
        }

        [HttpDelete("delete/{lsImgId}"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<LiveSellingImage>>>> DeleteLiveSelling(long lsImgId)
        {
            var result = await _liveSellingImageService.DeleteLiveSellingImage(lsImgId);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<List<LiveSellingImage>>>> AddLiveSellingImage(LiveSellingImage liveSellingImg)
        {
            var result = await _liveSellingImageService.AddLiveSellingImage(liveSellingImg);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<List<LiveSellingImage>>>> UpdateLiveSelling(LiveSellingImage liveSellingImg)
        {
            var result = await _liveSellingImageService.UpdateLiveSellingImage(liveSellingImg);
            return Ok(result);
        }
    }
}
