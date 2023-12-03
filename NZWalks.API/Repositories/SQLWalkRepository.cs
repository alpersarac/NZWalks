using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _dbcontext;
        public SQLWalkRepository(NZWalksDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _dbcontext.AddAsync(walk);
            await _dbcontext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walkModel = await _dbcontext.Walks.FindAsync(id);
            _dbcontext.Remove(walkModel);
            await _dbcontext.SaveChangesAsync();
            return walkModel;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await _dbcontext.Walks.Include(x=>x.Difficulty).Include(x=>x.Region).ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Walks.Include(x => x.Difficulty).Include(x => x.Region).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Walk?> UpdateAsync(Guid id,Walk walk)
        {
            var walkModel = await _dbcontext.Walks.FindAsync(id);
            if (walkModel!=null)
            {
                _dbcontext.Walks.Update(walk);
                await _dbcontext.SaveChangesAsync();
            }
            return null;
        }
    }
}
