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

        

        public async Task<bool?> UpdateStackbyId(string stackId, Stack entity)
        {
            var existingStack = await _context.Stacks.FindAsync(stackId);
            if (existingStack == null)
            {
                return null;
            }
            existingStack.StackName = entity.StackName;
            existingStack.DateUpdated = DateTime.UtcNow;
            _context.Stacks.Update(existingStack);
            var updateResult = await _context.SaveChangesAsync();
            if (updateResult > 0)
            {
                return true;
            }
            return false;
        }
    }
}