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
    }
}