using CMS.DATA.Context;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.DATA.Repository.Implementation
{
    public class ActivitiesRepo : IActivitiesRepo
    {
        private readonly CMSDbContext _context;

        public ActivitiesRepo(CMSDbContext context)
        {
            _context = context;
        }

        public List<Activity>GetAll()
        {
            var activities = _context.Activities.ToList();


            return activities;

        } 

        public Activity Delete(string id)
        {
            var activity = _context.Activities.FirstOrDefault(a => a.Id == id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
            return activity;
        }
    }
}