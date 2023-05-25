using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
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