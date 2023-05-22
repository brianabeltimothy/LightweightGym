namespace LightweightGymAPI.Repositories
{
    public interface IActivityRepository
    {
        Task<Entities.Activity> GetAsync(int contractorId);
        Task<IEnumerable<Entities.Activity>> GetAllAsync();
    }
}
