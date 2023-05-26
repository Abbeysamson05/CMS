using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
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

        [HttpGet("{stackId}/get-users")]
        public async Task<ActionResult<List<ApplicationUser>>> GetUsersByStack(string stackId)
        {
            var users = await _stacksService.GetUsersByStack(stackId);
            return Ok(users);
        }
    }
}