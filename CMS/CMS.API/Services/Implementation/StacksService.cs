using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class StacksService : IStacksService
    {
        private readonly IStacksRepo _stacksRepo;

        public StacksService(IStacksRepo stacksRepo)
        {
            _stacksRepo = stacksRepo;
        }

        public async Task<ResponseDto<Stack>> GetStackbyId(string id)
        {
            var response = new ResponseDto<Stack>();

            try
            {
                var stack = await _stacksRepo.GetStackAsync(id);
                response.StatusCode = 200;
                response.DisplayMessage = "Stack retrieved successfully";
                response.Result = stack;
            }
            catch (Exception ex)
            {

                response.StatusCode = 500;
                response.DisplayMessage = "An error occurred while retrieving the stack";
                response.ErrorMessages = new List<string>
                { ex.Message};
            }
            if (response.Result == null) 
            { 
                response.Result = new Stack();
            }
            return response;
        }



        public ResponseDto<List<string>> GetStacks()
        {
            var stacks = _stacksRepo.GetStacks();

            var response = new ResponseDto<List<string>>
            {
                StatusCode = 200,
                DisplayMessage = "All stacks returned",
                Result = stacks
            };

            return response;
        }
    }
}