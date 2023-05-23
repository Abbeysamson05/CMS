using CMS.DATA.Enum;
using CMS.DATA.DTO;
using CMS.DATA.Entities;

namespace CMS.API.Services.ServicesInterface
{
    public interface ILessonsService
    {
        Task<Lesson> AddLessonNew(Lesson lesson);
        Task<bool> DeleteLessonbyid(string lessonid);
        Task<IEnumerable<LessonResponseDTO>> GetLessonByModuleAsync(Modules lessonModule);
        Task<Lesson> UpdateLesson(UpdateLessonDTO lesson, string lessonId);
    }
}