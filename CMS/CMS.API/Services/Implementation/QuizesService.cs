using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CMS.API.Services
{
    public class QuizesService : IQuizesService
    {
        private readonly IQuizesRepo _quizesRepo;

        public QuizesService(IQuizesRepo quizesRepo)
        {
            _quizesRepo = quizesRepo;
        }

        public async Task<ResponseDto<Quiz>> GetByLesson(string lessonId)
        { 
            var lesson = await _quizesRepo.GetQuizByLessonAsync(lessonId);
            var response = new ResponseDto<Quiz>();
            if (lesson == null)
            {
                response.StatusCode = 404;
                response.ErrorMessages = new List<string> { "Lesson not Found" };
            }
            else
            {
                response.StatusCode = 200;
                response.DisplayMessage = "Operation Successful";
                response.Result = new Quiz
                {
                    LessonId = lesson.LessonId,
                    Question = lesson.Question,
                    AddedById = lesson.AddedById
                };
            }

           return response;
          
        }

        public async Task<ResponseDto<Quiz>> GetByUser(string userId)
        {
            var getUser = await _quizesRepo.GetQuizByUserAsync(userId);
            if (getUser == null)
                return new ResponseDto<Quiz> 
                { 
                    StatusCode = 404, 
                    ErrorMessages = new List<string> { "User not Found" } 
                };

            return new ResponseDto<Quiz>
            {
                StatusCode = 200,
                DisplayMessage = "Operation Successful",
                Result = new Quiz
                {
                    Question = getUser.Question,
                    AnswerType = getUser.AnswerType,
                    AddedById = getUser.AddedById,
                    PreferedAnswer = getUser.PreferedAnswer,
                    LessonId = getUser.LessonId
                }
            };
     
        }

        public async Task<IEnumerable<Quiz>> GetQuizAysnc()
        {
            var result = await _quizesRepo.GetAllQuizAsync();
            if (result != null && result.Any())
            {
                return result;
            }
            
            return null;


        }

        public async Task<ResponseDto<Quiz>> GetQuizByIdAsync(string id)
        {
            var quizId = await _quizesRepo.GetQuizByIdAsync(id);

            if (quizId == null)
                return new ResponseDto<Quiz> 
                { 
                    StatusCode = 404, 
                    ErrorMessages = new List<string> { "Quiz not found" }
                };

            return new ResponseDto<Quiz> 
            { 
                StatusCode = 200, 
                DisplayMessage = "Operation Successful",
                Result = new Quiz
                {
                    Question = quizId.Question,
                    AnswerType = quizId.AnswerType,
                    PreferedAnswer = quizId.PreferedAnswer,
                    AddedById = quizId.AddedById,
                    DateCreated = quizId.DateCreated,
                    DateUpdated = quizId.DateUpdated
                }
            };
        }
    }
}