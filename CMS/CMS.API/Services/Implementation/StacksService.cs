using AutoMapper;
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
        private readonly IMapper _mapper;

        public StacksService(IStacksRepo stacksRepo, IMapper mapper)
        {
            _stacksRepo = stacksRepo;
            _mapper = mapper;
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

                response.ErrorMessages.Add(ex.Message);
                response.DisplayMessage = "Error";
                return response;
            }
        }

        

        public async Task<ResponseDto<string>> UpdateStackById(string stackid, UpdateStacksDto stack)
        {

            try
            {
                var _stack = _mapper.Map<Stack>(stack);
                var updateRepoResult = await _stacksRepo.UpdateStackbyId(stackid, _stack);

                if (updateRepoResult == null)
                {
                    var res = new ResponseDto<string>()
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        DisplayMessage = "Stack doesn't exist",
                        ErrorMessages = new List<string>() { "" },
                        Result = ""
                    };
                    return res;
                }else if(updateRepoResult == true)
                {
                    var res = new ResponseDto<string>()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        DisplayMessage = "Successfull",
                        Result = "stack updated successfully"
                    };
                    return res;
                }
                else
                {
                    var res = new ResponseDto<string>()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        DisplayMessage = "Stack not updated suceessfully",
                        ErrorMessages = new List<string>() { "" },
                        Result = ""
                    };
                    return res;
                }
            }
            catch (Exception ex)
            {
                var res = new ResponseDto<string>()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    DisplayMessage = "Stack not updated suceessfully",
                    ErrorMessages = new List<string>() { "" },
                    Result = ""
                };
                return res;
            }
        }
    }
}