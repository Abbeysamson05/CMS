using AutoMapper;
using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.DATA.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/lesson")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonsService _lessonsService;
        private readonly IMapper _mapper;

        public LessonsController(ILessonsService lessonsService, IMapper mapper)
        {
            _lessonsService = lessonsService;
            _mapper = mapper;
        }
        //[Authorize(Roles = "Facilitator, Admin")]
        //[Authorize(Policy = "can_add")]
        [HttpPost("add")]
        public async Task<IActionResult> AddLesson(AddLessonDTO addLesson)
        {
            var newlesson = _mapper.Map(addLesson, new Lesson());
            var result = await _lessonsService.AddLessonNew(newlesson);
            var addlessonDto = _mapper.Map(result, new LessonResponseDTO());
            var responseDto = new ResponseDto<LessonResponseDTO>();
            responseDto.DisplayMessage = "Successsfull";
            responseDto.StatusCode = StatusCodes.Status200OK;
            responseDto.Result = addlessonDto;
            return Ok(responseDto);
        }

        //[Authorize(Roles = "Facilitator, Admin")]
        //[Authorize(Policy = "can_delete")]
        [HttpDelete("{lessonid}/delete")]
        public async Task<IActionResult> DeleteLeson(string lessonid)
        {
            try
            {
                var result = await _lessonsService.DeleteLessonbyid(lessonid);
                if (result == true)
                {
                    return NoContent();
                }
                var ErrorMessage = new ResponseDto<ErrorMessageDto>();
                ErrorMessage.DisplayMessage = "Lesson was not deleted";
                ErrorMessage.StatusCode = StatusCodes.Status400BadRequest;

                return BadRequest(ErrorMessage);
            }
            catch (Exception ex)
            {
                var ErrorMessage = new ResponseDto<ErrorMessageDto>();
                ErrorMessage.DisplayMessage = ex.Message;
                ErrorMessage.StatusCode = StatusCodes.Status400BadRequest;
                return BadRequest(ErrorMessage);
            }
        }
        //[Authorize]
        [HttpGet("{moduleid}")]
        public async Task<IActionResult> GetLessonByModule(Modules moduleid)
        {
            var response = new ResponseDto<IEnumerable<LessonResponseDTO>>();
            var result = await _lessonsService.GetLessonByModuleAsync(moduleid);
            if (result.Count() == 0)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.DisplayMessage = "lesson with the module not found";
                return NotFound(response);
            }
            response.DisplayMessage = "Successful";
            response.Result = result;
            response.StatusCode = StatusCodes.Status200OK;
            return Ok(response);
        }

        //[Authorize(Policy = "can_update")]
        //[Authorize(Roles = "Facilitator, Admin")]
        [HttpPut("{lessonId}/update")]
        public async Task<IActionResult> AddLesson(UpdateLessonDTO lesson, string lessonId)
        {
            var result = await _lessonsService.UpdateLesson(lesson, lessonId);
            var updateResultlesson = _mapper.Map(result, new LessonResponseDTO());
            var responseDto = new ResponseDto<LessonResponseDTO>();
            responseDto.DisplayMessage = "Successsful";
            responseDto.StatusCode = StatusCodes.Status200OK;
            responseDto.Result = updateResultlesson;
            return Ok(responseDto);
        }

    }
}