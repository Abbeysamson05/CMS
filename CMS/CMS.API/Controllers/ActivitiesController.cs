using CMS.API.Services.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesService _activitiesService;

        public ActivitiesController(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        [HttpGet]
        public IActionResult GetAllActivities() 
        {
            var activities = _activitiesService.GetAllActivities();
            if(activities == null) 
            {
                return NotFound();
            }

            return Ok(activities);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActivity(string id) 
        {
            var deletedActivity = _activitiesService.DeleteActivity(id);
            if(deletedActivity == null) 
            {
                return NotFound();
            }
            return NoContent(); 
        }
    }
}