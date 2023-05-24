using CMS.DATA.Context;
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

        public async Task<Quiz> AddQuiz(Quiz entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Quizs.AddAsync(entity);
            var Status = await _context.SaveChangesAsync();

            if (Status > 0)
                return entity;

            return null;
        }



        public async Task<Quiz> DeleteQuizAsync(Quiz entity)
        {
            _context.Quizs.Remove(entity);
            var status = await _context.SaveChangesAsync();

            if (status > 0)
                return entity;

            return null;
        }

        public async Task<Quiz> UpdateQuiz(Quiz entity)
        {

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Quizs.Update(entity);
            var status = await _context.SaveChangesAsync();

            if (status > 0)
                return entity;

            return null;
        }
        public async Task<Quiz> GetQuizByIdAsync(string Id)
        {


            var result = await _context.Quizs.FirstOrDefaultAsync(b => b.Id == Id);
            if (result == null)
            {
                throw new Exception("Quiz not available");
            }

            return result;
        }
    }
}