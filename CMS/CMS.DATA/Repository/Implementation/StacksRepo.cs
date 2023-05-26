using CMS.DATA.Context;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.DATA.Repository.Implementation
{
    public class StacksRepo : IStacksRepo
    {
        private readonly CMSDbContext _context;

        public StacksRepo(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<Stack> GetStackAsync(string stackid)
        {
            return await _context.Stacks.FindAsync(stackid);
        }

        public List<string> GetStacks()
        {
            var stacks = _context.Stacks.Select(stack => stack.StackName).ToList();
            return stacks;
        }
    }
}