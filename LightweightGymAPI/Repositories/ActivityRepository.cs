using LightweightGymAPI.DbContext;
using LightweightGymAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LightweightGymAPI.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ActivityRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _dbContext.Activities.ToListAsync();
        }

        public async Task<Activity> GetAsync(int activityId)
        {
            return await _dbContext.Activities.FindAsync(activityId);
        }

        public void Add(Activity activity)
        {
            _dbContext.Activities.Add(activity);
        }

        public void Delete(Activity activity)
        {
            _dbContext.Activities.Remove(activity);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

}
