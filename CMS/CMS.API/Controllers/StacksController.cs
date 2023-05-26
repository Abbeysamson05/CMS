using CMS.API.Services.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StacksController : ControllerBase
    {
        private readonly IStacksService _stacksService;

        public StacksController(IStacksService stacksService)
        {
            _stacksService = stacksService;
        }

        [HttpGet("all")]
        public IActionResult GetAllStacks()
        {
            var responseDto = _stacksService.GetStacks();
            return Ok(responseDto);
        }

        [HttpGet("{stackId}")]
        public async Task<IActionResult> GetStackById (string stackId) 
        {
            var response = await _stacksService.GetStackbyId(stackId);

            if (response.StatusCode == 200)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(response.StatusCode, response);
            }
        }
    }
}