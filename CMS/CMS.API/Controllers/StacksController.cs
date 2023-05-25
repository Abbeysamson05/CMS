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
    }
}