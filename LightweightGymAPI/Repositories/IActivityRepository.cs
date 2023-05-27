using LightweightGymAPI.Entities;

namespace LightweightGymAPI.Repositories
{
    public interface IActivityRepository
    {
        Task<Entities.Activity> GetAsync(int contractorId);
        Task<IEnumerable<Entities.Activity>> GetAllAsync();
        void Add(Activity activity);
        void Delete(Activity activity);
        Task SaveAsync();
    }
}
