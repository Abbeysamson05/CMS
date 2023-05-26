using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
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

        public async Task<ResponseDto<IEnumerable<Stack>>> GetStacks()
        {
            var response = new ResponseDto<IEnumerable<Stack>>();
            try
            {
                var result = await _stacksRepo.GetStacks();
                response.DisplayMessage = "Successfull";
                response.StatusCode = StatusCodes.Status200OK;
                response.Result = result;
                return response;

            }
            catch (Exception ex)
            {

                response.ErrorMessages.Add("Error in retriving stack");
                response.DisplayMessage = "Error";
                return response;
            }
        }

        public async Task<ResponseDto<List<UserDto>>> GetUsersByStack(string stackId)
        {
            var response = new ResponseDto<List<UserDto>>();
            try
            {
                var users = await _stacksRepo.GetUsersByStack(stackId);
                response.StatusCode = 200;
                response.DisplayMessage = "Stack users returned";
                response.Result = users;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.DisplayMessage = "An error occurred while retrieving stack users";
                response.ErrorMessages = new List<string> { ex.Message };
            }
            if (response.Result == null)
            {
                response.Result = new List<UserDto>();
            }
            return response;
        }
    }
}