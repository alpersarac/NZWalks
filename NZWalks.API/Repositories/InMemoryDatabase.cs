using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class InMemoryDatabase : IRegionRepository
    {
        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>{
                new Region()
                {
                    Id=Guid.NewGuid(),
                    code="Alper",
                    name="Sarac",
                }
            };
        }
    }
}
