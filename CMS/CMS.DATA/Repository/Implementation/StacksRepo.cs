using CMS.DATA.Context;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;
using Microsoft.EntityFrameworkCore;


namespace CMS.DATA.Repository.Implementation
{
    public class StacksRepo : IStacksRepo
    {
        private readonly CMSDbContext _context;

        public StacksRepo(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stack>> GetStacks()
        {
            var stacks = await _context.Stacks.ToListAsync();
            return stacks;
        }
    }
}