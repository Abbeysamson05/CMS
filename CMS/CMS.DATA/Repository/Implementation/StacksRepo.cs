using AutoMapper;
using CMS.DATA.Context;
using CMS.DATA.DTO;
using CMS.DATA.Repository.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using CMS.DATA.Context;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;
using Microsoft.EntityFrameworkCore;


namespace CMS.DATA.Repository.Implementation
{
    public class StacksRepo : IStacksRepo
    {
        private readonly CMSDbContext _context;
        private readonly IMapper _mapper;

        public StacksRepo(CMSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Stack>> GetStacks()
        {
            var stacks = await _context.Stacks.ToListAsync();
            return stacks;
        }

        public async Task<List<UserDto>> GetUsersByStack(string stackId)
        {
            var userStacks = await _context.UserStack
                .Include(us => us.User)
                .Where(us => us.StackId == stackId)
                .Select(us => us.User)
                .ToListAsync();
            return _mapper.Map<List<UserDto>>(userStacks);
        }
    }
}