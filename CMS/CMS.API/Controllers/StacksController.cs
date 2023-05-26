using CMS.API.Services.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/stack")]
    [ApiController]
    public class StacksController : ControllerBase
    {
        private readonly IStacksService _stacksService;

        public StacksController(IStacksService stacksService)
        {
            _stacksService = stacksService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllStacks()
        {
            var responseDto = await _stacksService.GetStacks();
            if(responseDto.StatusCode == 200)
            {
                return Ok(responseDto);
            }
            else
            {
                return BadRequest(responseDto);
            }
        }
    }
}