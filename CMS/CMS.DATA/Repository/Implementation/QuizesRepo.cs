﻿using CMS.DATA.Context;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace CMS.DATA.Repository.Implementation
{
    public class QuizesRepo : IQuizesRepo
    {
        private readonly CMSDbContext _context;

        public QuizesRepo(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quiz>> GetAllQuizAsync()
        {
            return await _context.Quizs.ToListAsync();
        }

        public async Task<Quiz> GetQuizByIdAsync(string quizId)
        {
            return await _context.Quizs.FirstOrDefaultAsync(e => e.Id == quizId);
        }
   

        public async Task<Quiz> GetQuizByLessonAsync(string lessonId)
        {
            var lesson = await _context.Lessons.FindAsync(lessonId);
            if (lesson == null)
                throw new Exception("Lesson does not exist");
            return await _context.Quizs.FirstOrDefaultAsync(e => e.LessonId == lessonId);
        }

        public async Task<Quiz> GetQuizByUserAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new Exception("User does not exist");

            return await _context.Quizs.FirstOrDefaultAsync(e => e.AddedById== userId);
        }
    }
}