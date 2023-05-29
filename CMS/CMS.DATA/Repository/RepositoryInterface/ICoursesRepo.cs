﻿using CMS.DATA.DTO;
using CMS.DATA.Entities;

namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface ICoursesRepo
    {
        Task<ResponseDTO<Course>> GetCourseById(string courseId);
        Task<ResponseDTO<Course>> UpdateCourseAsync(string courseId, UpdateCourseDTO course);
        Task<ResponseDTO<bool>> DeleteCourseAsync(string courseId);
        void SetCourseAsCompleted(string courseId);
    }
}