using AutoMapper;
using CMS.DATA.DTO;
using CMS.DATA.Entities;

namespace CMS.API.Profiles
{
    public class CMSProfile : Profile
    {
        public CMSProfile()
        {
            CreateMap<AddLessonDTO, Lesson>().ReverseMap();
            CreateMap<Lesson, LessonResponseDTO>().ReverseMap();
        }
    }
}