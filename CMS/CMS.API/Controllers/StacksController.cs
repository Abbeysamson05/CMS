using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
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
            return Ok(responseDto);
        }

        [HttpPut("{stackid}/Update")]
        public async Task<ActionResult<ResponseDto<bool?>>> UpdateStackById(string stackid, [FromBody] UpdateStacksDto model)
        {
            var res = await _stacksService.UpdateStackById(stackid, model);
            if(res.StatusCode ==  200)
            {
                return Ok(res);
            }else if(res.StatusCode == 404)
            {
                return NotFound(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}