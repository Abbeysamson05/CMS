using AutoMapper;
using CMS.DATA.Enum;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class LessonsService : ILessonsService
    {
        private readonly ILessonsRepo _lessonsRepo;
        private readonly IMapper _mapper;

        public LessonsService(ILessonsRepo lessonsRepo, IMapper mapper)
        {
            _lessonsRepo = lessonsRepo;
            _mapper = mapper;
        }

        public async Task<Lesson> AddLessonNew(Lesson lesson)
        {
            var result = await _lessonsRepo.AddLesson(lesson);
            return result;

        }

        public async Task<bool> DeleteLessonbyid(string lessonid)
        {
            var result = await _lessonsRepo.DeleteLesson(lessonid);
            return result;
        }
       
        
        public async Task<IEnumerable<LessonResponseDTO>> GetLessonByModuleAsync(Modules lessonModule)
        {
            var result = await _lessonsRepo.GetLessonByModule(lessonModule);
            return result;
        }

        public async Task<Lesson> UpdateLesson(UpdateLessonDTO lesson, string lessonId)
        {
            var result = await _lessonsRepo.UpdateLesson(lesson, lessonId);
            return result;
        }
    }
}