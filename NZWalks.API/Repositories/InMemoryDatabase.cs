using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class InMemoryDatabase : IRegionRepository
    {
        public Task<Region> CreateAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>{
                new Region()
                {
                    Id=Guid.NewGuid(),
                    Code="Alper",
                    Name="Sarac",
                }
            };
        }

        public Task<Region?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> UpdateAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
