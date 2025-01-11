using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Regions>> GetAllAsync();

        Task<Regions> GetByIdAsync(Guid id);

        Task<Regions> CreateAsync(Regions region);

        Task<Regions?> UpdateAsync(Guid id, Regions region);

        Task<Regions?> DeleteAsync(Guid id);
    }
}
