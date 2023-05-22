using LightweightGymAPI.DbContext;
using LightweightGymAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LightweightGymAPI.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivityRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Entities.Activity> GetAsync(int activityId)
        {
            return await _context.Activities.FirstOrDefaultAsync(x => x.ActivityId == activityId);
        }

        public async Task<IEnumerable<Entities.Activity>> GetAllAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public Task<Activity> GetAsync(Guid contractorId)
        {
            throw new NotImplementedException();
        }
    }
}
