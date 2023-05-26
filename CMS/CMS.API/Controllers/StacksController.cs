using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
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

        [HttpGet("{stackId}/get-users")]
        public async Task<ActionResult<List<ApplicationUser>>> GetUsersByStack(string stackId)
        {
            var users = await _stacksService.GetUsersByStack(stackId);
            return Ok(users);
        }
    }
}